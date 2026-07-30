using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WooCommerce.Application.DTOs;
using WooCommerce.Application.Services.Interfaces;

namespace WooCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly IZohoDealService _dealService;

        public DealsController(IZohoDealService dealService)
        {
            _dealService = dealService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DealDto dto)
        {
            var dealId = await _dealService.CreateDealAsync(dto);

            return Ok(new
            {
                Message = "Deal Created Successfully",
                DealId = dealId
            });
        }
    }
}
