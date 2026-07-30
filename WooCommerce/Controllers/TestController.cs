using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WooCommerce.Application.Services.Interfaces;

namespace WooCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IZohoAuthService _authService;

        public TestController(IZohoAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            var token = await _authService.GetAccessTokenAsync();

            return Ok(token);
        }
    }
}
