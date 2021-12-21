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
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ContactInfoGetModel>), 200)]
        public async Task<IActionResult> GetUserInfos(string id)
        {
            var datas = await _contactInfoService.GetUserContactInfoAsync(id);
            return Ok(datas);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactInfoGetModel), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _contactInfoService.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ContactInfoGetModel), 200)]
        public async Task<IActionResult> Add(ContactInfoAddModel model)
        {
            var data = await _contactInfoService.AddAsync(model);
            return Ok(data);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ContactInfoGetModel), 200)]
        public async Task<IActionResult> Update(ContactInfoUpdateModel model)
        {
            var data = await _contactInfoService.UpdateAsync(model);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _contactInfoService.SoftDeleteAsync(id);
            if (data) return Ok("Success.");
            return NotFound("Not Found!");
        }
    }
}
