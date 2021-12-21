using ContactApp.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRedisService _redisService;
        private readonly IContactService _contactService;
        public HomeController(IRedisService redisService, IContactService contactService)
        {
            _redisService = redisService;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _redisService.Get<string>("deneme");
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var data = await _contactService.AddAsync(new Model.ContactAddModel
            {
                FirstName="Deneme",
                LastName = "Deneme",
                Firm = "Deneme"
            });
            return Ok(data);
        }
    }
}
