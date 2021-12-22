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
    public class ReportControllerTest
    {
        private readonly Mock<IReportService> _mockReportService;
        private readonly ReportController _reportController;
        private readonly List<ReportGetModel> list;

        public ReportControllerTest()
        {
            _mockReportService = new Mock<IReportService>();
            _reportController = new ReportController(_mockReportService.Object);
            list = new List<ReportGetModel>
            {
                new ReportGetModel{Location="Şahinbey/Gaziantep", LocationCount=2, ContactCountInLocation=2, NumberCountInLocation=2},
                new ReportGetModel{Location="Şehitkamil/Gaziantep", LocationCount=1, ContactCountInLocation=1, NumberCountInLocation=1}
            };
        }

        [Fact]
        public async void Get_RegularExec_ReturnOkReportModelList()
        {
            _mockReportService.Setup(x => x.GetBasicReportAsync()).ReturnsAsync(list);

            var data = await _reportController.Get();

            var ok = Assert.IsType<OkObjectResult>(data);

            var returnObj = Assert.IsAssignableFrom<IEnumerable<ReportGetModel>>(ok.Value);

            Assert.Equal<int>(2, returnObj.Count());
        }
    }
}
