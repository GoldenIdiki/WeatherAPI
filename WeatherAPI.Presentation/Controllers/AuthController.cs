using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Domain.Contracts.Services.Identity;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<AuthDTO>>> Login(AuthRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.Login(request);
                return Ok(result);
            }
            else { return BadRequest(); }
        }
    }
}
