using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;

namespace WeatherAPI.Domain.Contracts.Services.Weather
{
    public interface IWeatherService
    {
        Task<ServiceResponse<WeatherDTO>> GetWeatherDetails(WeatherRequest request);
    }
}
