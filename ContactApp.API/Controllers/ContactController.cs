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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _contactService.GetAllNonDeleteAsync();
            return Ok(data);
        }
        [HttpGet("{id:string}")]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("'id' is not null!");
            }
            var data = await _contactService.GetByIdAsync(id);
            return Ok(data);
        }
    }
}
