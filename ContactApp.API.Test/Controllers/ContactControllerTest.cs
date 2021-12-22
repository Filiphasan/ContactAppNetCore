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
    public class ContactControllerTest
    {
        private readonly Mock<IContactService> _mockContactService;
        private readonly ContactController _contactController;
        private readonly List<ContactGetModel> listContactGetModel;
        public ContactControllerTest()
        {
            _mockContactService = new Mock<IContactService>();
            _contactController = new ContactController(_mockContactService.Object);
            listContactGetModel = new List<ContactGetModel>
            {
                new ContactGetModel{ Id = "06aa8dd6-12b2-45f0-9087-222889639d1c", FirstName = "Mehmet", LastName = "Erdal", Firm = "No Firm", ContactInfos = null},
                new ContactGetModel{ Id = "13539989-0439-4698-b694-ad6a8e65d5ab", FirstName = "Mustafa", LastName = "Erdal", Firm = "No Firm", ContactInfos = null},
                new ContactGetModel{ Id = "e96bb9b2-0d70-4c8f-8344-20872e24010c", FirstName = "Hasan", LastName = "Erdal", Firm = "Rise Consulting", ContactInfos = null}
            };
        }
        [Fact]
        public async void GetAll_RegularExecute_ReturnOkList()
        {
            _mockContactService.Setup(x => x.GetAllNonDeleteAsync()).ReturnsAsync(listContactGetModel);

            var data = await _contactController.GetAll();

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<IEnumerable<ContactGetModel>>(ok.Value);

            Assert.Equal<int>(3, returnObj.Count());

        }

        [Theory]
        [InlineData("e96bb9b2-0d70-4c8f-8344-20872e24010c")]
        public async void GetWithInfo_RegularExecute_ReturnOkContact(string id)
        {
            var contact = listContactGetModel.LastOrDefault();
            var contactInfoGet = new ContactInfoGetModel
            {
                Id = 1,
                Key = "Telefon Numarası",
                Value = "+90 537 035 2059",
                ContactId = "e96bb9b2-0d70-4c8f-8344-20872e24010c"
            };
            var listInfo = new List<ContactInfoGetModel>();
            listInfo.Add(contactInfoGet);
            contact.ContactInfos = listInfo;
            _mockContactService.Setup(x => x.GetByIdWithInfosAsync(id)).ReturnsAsync(contact);


            var data = await _contactController.GetWithInfo(id);

            var ok = Assert.IsType<OkObjectResult>(data);

            var retunObj = Assert.IsAssignableFrom<ContactGetModel>(ok.Value);

            Assert.Equal(id, contact.ContactInfos.FirstOrDefault().ContactId);
        }
        [Theory]
        [InlineData("e96bb9b2-0d70-4c8f-8344-20872e24010c")]
        public async void Get_RegularExecute_ReturnOkContact(string id)
        {
            var contact = listContactGetModel.LastOrDefault();

            _mockContactService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(contact);


            var data = await _contactController.Get(id);

            var ok = Assert.IsType<OkObjectResult>(data);

            var retunObj = Assert.IsAssignableFrom<ContactGetModel>(ok.Value);

            Assert.Null(retunObj.ContactInfos);
        }
        [Fact]
        public async void Add_RegularDataPost_ReturnOkContact()
        {
            var contactGet = listContactGetModel.FirstOrDefault();
            var contactAdd = new ContactAddModel { FirstName = contactGet.FirstName, LastName = contactGet.LastName, Firm = contactGet.Firm};

            _mockContactService.Setup(x => x.AddAsync(contactAdd)).ReturnsAsync(contactGet);

            var data = await _contactController.Add(contactAdd);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<ContactGetModel>(ok.Value);

            Assert.IsType<ContactGetModel>(returnObj);

            Assert.Null(returnObj.ContactInfos);

        }
        [Theory]
        [InlineData("e96bb9b2-0d70-4c8f-8344-20872e24010c")]
        public async void Delete_RegularExec_ReturnsOkStr(string id)
        {
            _mockContactService.Setup(x => x.SoftDeleteAsync(id)).ReturnsAsync(true);

            var data = await _contactController.Delete(id);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<string>(ok.Value);

            Assert.Equal("Success.", returnObj);
        }
        [Theory]
        [InlineData("")]
        public async void Delete_IdWrong_ReturnNotFound(string id)
        {
            _mockContactService.Setup(x => x.SoftDeleteAsync(id)).ReturnsAsync(false);

            var data = await _contactController.Delete(id);

            var not = Assert.IsType<NotFoundObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<string>(not.Value);

            Assert.Equal("Id not found!", returnObj);
        }
        [Theory]
        [InlineData("")]
        public async void Update_RegularExecute_ReturnOkContact(string id)
        {
            var contact = listContactGetModel.FirstOrDefault();
            var contactUpdate = new ContactUpdateModel { Id = contact.Id, FirstName = contact.FirstName, LastName = contact.LastName, Firm = contact.Firm};

            _mockContactService.Setup(x => x.UpdateAsync(contactUpdate)).ReturnsAsync(contact);

            var data = await _contactController.Update(contactUpdate);

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<ContactGetModel>(ok.Value);

            Assert.IsType<ContactGetModel>(returnObj);

            Assert.Null(returnObj.ContactInfos);
        }


    }
}
