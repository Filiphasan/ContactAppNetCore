using ContactApp.API.Data.Model;
using ContactApp.API.Helpers;
using ContactApp.API.Interfaces;
using ContactApp.API.Model;
using ContactApp.API.Services;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactApp.API.Test.Services
{
    public class ContactServiceTest
    {
        private readonly Mock<IContactRepository> _mockContactRepository;
        private readonly Mock<IContactInfoRepository> _mockContactInfoRepository;
        private readonly Mock<IRedisService> _mockRedisService;
        private readonly ContactCacheKeys _contactCacheKeys;
        private readonly ContactCacheStringHelpers _contactCacheStringHelpers;
        private readonly ContactService _contactService;
        private readonly List<Contact> list;

        public ContactServiceTest()
        {
            _mockContactInfoRepository = new Mock<IContactInfoRepository>();
            _mockContactRepository = new Mock<IContactRepository>();
            _mockRedisService = new Mock<IRedisService>();
            IOptions<ContactCacheKeys> contactCacheKeysOpt = Options.Create<ContactCacheKeys>(new ContactCacheKeys { OneContact = "contact-{0}", MultiContact = "contacts-{0}", OneContactWithInfos = "contact-with-infos-{0}", MultiContactWithInfos = "contacts-with-infos-{0}" });
            IOptions<ContactCacheStringHelpers> contactCacheStrHelpOptions = Options.Create<ContactCacheStringHelpers>(new ContactCacheStringHelpers { FilterAll = "all", FilterAllNonDelete = "all-nondelete" });
            _contactCacheKeys = contactCacheKeysOpt.Value;
            _contactCacheStringHelpers = contactCacheStrHelpOptions.Value;
            _contactService = new ContactService(_mockContactRepository.Object, _mockContactInfoRepository.Object, _mockRedisService.Object, contactCacheKeysOpt, contactCacheStrHelpOptions);
            list = new List<Contact>
            {
                new Contact{Id="06aa8dd6-12b2-45f0-9087-222889639d1c",FirstName="Mehmet",LastName="Erdal",Firm="No Firm",CreatedAt=DateTime.Parse("2021-12-21 15:23:51.5856796"),UpdatedAt=DateTime.Parse("2021-12-21 15:23:51.5856796"),IsDeleted=false},
                new Contact{Id="13539989-0439-4698-b694-ad6a8e65d5ab",FirstName="Mustafa",LastName="Erdal",Firm="No Firm",CreatedAt=DateTime.Parse("2021-12-21 15:23:51.5856796"),UpdatedAt=DateTime.Parse("2021-12-21 15:23:51.5856796"),IsDeleted=false},
                new Contact{Id="e96bb9b2-0d70-4c8f-8344-20872e24010c",FirstName="Hasan",LastName="Erdal",Firm="Rise Consulting",CreatedAt=DateTime.Parse("2021-12-21 15:23:51.5856796"),UpdatedAt=DateTime.Parse("2021-12-21 15:23:51.5856796"),IsDeleted=false}
            };
        }
        [Fact]
        public async void AddAsync_RegularData_ReturnContactGet()
        {
            var contact = list.LastOrDefault();
            var contactAddModel = new ContactAddModel { FirstName = contact.FirstName, LastName = contact.LastName, Firm = contact.Firm };
            var contactGet = new ContactGetModel { Id = contact.Id, FirstName = contact.FirstName, LastName = contact.LastName, Firm = contact.Firm, ContactInfos = null };
            var listGetModel = list.Select(x => new ContactGetModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Firm = x.Firm, ContactInfos = null });

            _mockContactRepository.Setup(x => x.InsertAsyncReturn(contact)).ReturnsAsync(contact);
            //_mockRedisService.Setup(x => x.Set<ContactGetModel>(string.Format(_contactCacheKeys.OneContact, contactGet.Id), contactGet));
            //_mockRedisService.Setup(x => x.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll))).Returns(listGetModel);
            //_mockRedisService.Setup(x => x.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete))).Returns(listGetModel);
            //_mockRedisService.Setup(x => x.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll), listGetModel));
            //_mockRedisService.Setup(x => x.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), listGetModel));

            var data = await _contactService.AddAsync(contactAddModel);

            Assert.IsType<ContactGetModel>(data);
        }
    }
}
