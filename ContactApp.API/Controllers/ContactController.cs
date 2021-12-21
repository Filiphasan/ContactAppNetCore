using ContactApp.API.Interfaces;
using ContactApp.API.Model;
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
        [ProducesResponseType(typeof(IEnumerable<ContactGetModel>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var data = await _contactService.GetAllNonDeleteAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactGetModel), 200)]
        public async Task<IActionResult> Get(string id)
        {
            var data = await _contactService.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ContactGetModel), 200)]
        [ProducesResponseType(typeof(ContactGetModel), 201)]
        public async Task<IActionResult> Add(ContactAddModel model)
        {
            var data = await _contactService.AddAsync(model);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _contactService.DeleteAsync(id);
            if (data)
            {
                return Ok("Success.");
            }
            return NotFound("Id not found!");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ContactGetModel), 200)]
        public async Task<IActionResult> Update(ContactUpdateModel model)
        {
            var data = await _contactService.UpdateAsync(model);
            return Ok(data);
        }
    }
}
