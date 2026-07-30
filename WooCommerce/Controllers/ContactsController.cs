using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WooCommerce.Application.DTOs;
using WooCommerce.Application.Services.Interfaces;

namespace WooCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IZohoContactService _contactService;

        public ContactsController(IZohoContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ContactDto dto)
        {
            
            var contactId = await _contactService.CreateContactAsync(dto);

            return Ok(new
            {
                Message = "Contact Created Successfully",
                ContactId = contactId
            });
        }
    }
}
