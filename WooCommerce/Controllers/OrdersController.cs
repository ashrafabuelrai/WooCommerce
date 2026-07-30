using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WooCommerce.Application.DTOs;
using WooCommerce.Application.Services.Interfaces;

namespace WooCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IZohoOrderService _orderService;

        public OrdersController(
            IZohoOrderService orderService)
        {
            _orderService = orderService;
        }
       
        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            var result = await _orderService.CreateOrderAsync(dto);

            return Ok(new
            {
                Message = result
            });
        }
    }

}
