using WeatherAPI.Domain.Contracts.Infrastructure;
using WeatherAPI.Domain.Contracts.Services.Weather;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;

namespace WeatherAPI.Data.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IGenericRestClient _genericRestClient;

        public WeatherService(IGenericRestClient genericRestClient)
        {
            _genericRestClient = genericRestClient;
        }
        public async Task<ServiceResponse<WeatherDTO>> GetWeatherDetails(WeatherRequest request)
        {
            var result = await _genericRestClient.GetWeatherDetails(request);
            return result;
        }
    }
}
