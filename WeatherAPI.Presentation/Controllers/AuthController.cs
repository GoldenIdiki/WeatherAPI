using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherAPI.Domain.Contracts.Services.Identity;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;
using WeatherAPI.Presentation.Middleware;

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

        /// <summary>
        /// A registered user can login in order to be authorized to request weather details for a particular location
        /// A token is generated upon login which contains the user's details
        /// </summary>
        /// <param name="request"></param>
        /// <returns code="200">It returns some of the user details alongside the token which will be used to validate the user</returns>
        /// <response code="200">Returns 200 if the user is logged in successfully</response>
        /// <response code="400">Returns 400 if the input is invalid</response>
        /// <response code="401">Returns 401 if there is an authorized access </response>
        /// <response code="500">Returns 500 if a system error occurs while trying to log the user in</response>
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponse<AuthDTO>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails<object>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails<object>))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ErrorDetails<object>))]
        public async Task<ActionResult<ServiceResponse<AuthDTO>>> Login(AuthRequest request)
        {
            try
            {
                request.Validate();
                var result = await _authenticationService.Login(request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// A user can create an account in order to get weather details for a particular location
        /// </summary>
        /// <param name="request"></param>
        /// <returns code="200">It returns some details of the user if the account is created successfully</returns>
        /// <response code="200">Returns 200 if the user creates the account successfully</response>
        /// <response code="400">Returns 400 if the input is invalid</response>
        /// <response code="500">Returns 500 if a system error occurs when the user is trying to create the account</response>
        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponse<RegistrationDTO>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails<object>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails<object>))]
        public async Task<ActionResult<ServiceResponse<RegistrationDTO>>> CreateAccount([FromBody] RegistrationRequest request)
        {
            try
            {
                request.Validate();
                var result = await _authenticationService.CreateAccount(request);
                return CreatedAtAction(nameof(CreateAccount), result);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
