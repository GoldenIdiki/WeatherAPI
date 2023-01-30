using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherAPI.Domain.Contracts.Services.Weather;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;
using WeatherAPI.Presentation.Middleware;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public UserController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Logged in users can request weather details of a particular location.
        /// </summary>
        /// <param name="request"></param>
        /// <returns code="200">A weatherDTO which contains the weather details of the location within a period of time</returns>
        /// <response code="200">Returns 200 and the weather details</response>
        /// <response code="400">Returns 400 if the input is invalid</response>
        /// <response code="401">Returns 401 if the user is not authorized to access this resource</response>
        /// <response code="500">Returns 500 if a system error occurred while getting the weather details</response>
        [Authorize(Roles = "Administrator")]
        [HttpPost("weather-details")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponse<WeatherDTO>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails<object>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails<object>))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ErrorDetails<object>))]
        public Task<ServiceResponse<WeatherDTO>> GetWeatherDetails(WeatherRequest request)
        {
            try
            {
                request.Validate();
                var result = _weatherService.GetWeatherDetails(request);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
