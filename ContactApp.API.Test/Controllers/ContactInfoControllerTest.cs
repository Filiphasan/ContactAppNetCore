using ContactApp.API.Controllers;
using ContactApp.API.Interfaces;
using ContactApp.API.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactApp.API.Test.Controllers
{
    public class ContactInfoControllerTest
    {
        private readonly Mock<IContactInfoService> _mockContactInfoService;
        private readonly ContactInfoController _contactInfoController;
        private readonly List<ContactInfoGetModel> list;

        public ContactInfoControllerTest()
        {
            _mockContactInfoService = new Mock<IContactInfoService>();
            _contactInfoController = new ContactInfoController(_mockContactInfoService.Object);
            list = new List<ContactInfoGetModel>
            {
                new ContactInfoGetModel{Id = 1, Key = "Telefon Numarası", Value="+90 537 035 2059", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 2, Key = "E-Mail Adresi", Value="hasaerda@hotmail.com", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 3, Key = "Konum", Value="Şahinbey/Gaziantep", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 4, Key = "Telefon Numarası", Value="+90 537 035 2059", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 5, Key = "E-Mail Adresi", Value="hasaerda@hotmail.com", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 6, Key = "Konum", Value="Şahinbey/Gaziantep", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 7, Key = "Telefon Numarası", Value="+90 537 035 2059", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 8, Key = "E-Mail Adresi", Value="hasaerda@hotmail.com", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
                new ContactInfoGetModel{Id = 9, Key = "Konum", Value="Şehitkamil/Gaziantep", ContactId="e96bb9b2-0d70-4c8f-8344-20872e24010c"},
            };
        }
        [Theory]
        [InlineData("e96bb9b2-0d70-4c8f-8344-20872e24010c")]
        public async void GetUserInfos_RegularExecute_ReturnOkContactInfoList(string id)
        {
            var newList = list.Take(3);

            _mockContactInfoService.Setup(x => x.GetUserContactInfoAsync(id)).ReturnsAsync(newList);

            var data = await _contactInfoController.GetUserInfos(id);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<IEnumerable<ContactInfoGetModel>>(ok.Value);

            Assert.Equal<int>(3, returnObj.Count());
        }
        [Theory]
        [InlineData(1)]
        public async void Get_RegularExec_ReturnOkContactInfo(int id)
        {
            var contactInfo = list.FirstOrDefault();

            _mockContactInfoService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(contactInfo);

            var data = await _contactInfoController.Get(id);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<ContactInfoGetModel>(ok.Value);

            Assert.Equal<int>(id, returnObj.Id);
        }
        [Fact]
        public async void Add_RegularData_ReturnOkContactInfo()
        {
            var contactInfo = list.FirstOrDefault();
            var contactInfoAdd = new ContactInfoAddModel { Key = contactInfo.Key, Value = contactInfo.Value, ContactId = contactInfo.ContactId };

            _mockContactInfoService.Setup(x => x.AddAsync(contactInfoAdd)).ReturnsAsync(contactInfo);

            var data = await _contactInfoController.Add(contactInfoAdd);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<ContactInfoGetModel>(ok.Value);
        }
        [Theory]
        [InlineData(1)]
        public async void Update_RegularData_ReturnOkContactInfoGet(int id)
        {
            var contactInfo = list.FirstOrDefault();
            var contactInfoUpdate = new ContactInfoUpdateModel { ContactId=contactInfo.ContactId, Id = contactInfo.Id, Key = contactInfo.Key, Value = contactInfo.Value};

            _mockContactInfoService.Setup(x => x.UpdateAsync(contactInfoUpdate)).ReturnsAsync(contactInfo);

            var data = await _contactInfoController.Update(contactInfoUpdate);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<ContactInfoGetModel>(ok.Value);
        }
        [Theory]
        [InlineData(1)]
        public async void Delete_RegularId_ReturnOkStrMsg(int id)
        {
            _mockContactInfoService.Setup(x => x.SoftDeleteAsync(id)).ReturnsAsync(true);

            var data = await _contactInfoController.Delete(id);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<string>(ok.Value);

            Assert.Equal("Success.", returnObj);
        }
        [Theory]
        [InlineData(0)]
        public async void Delete_WrongId_ReturnNotFoundStrMsg(int id)
        {
            _mockContactInfoService.Setup(x => x.SoftDeleteAsync(id)).ReturnsAsync(false);

            var data = await _contactInfoController.Delete(id);

            var notFound = Assert.IsType<NotFoundObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<string>(notFound.Value);

            Assert.Equal("Not Found!", returnObj);
        }
    }
}
