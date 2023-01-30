using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;

namespace WeatherAPI.Domain.Contracts.Infrastructure
{
    public interface IGenericRestClient
    {
        Task<ServiceResponse<WeatherDTO>> GetWeatherDetails(WeatherRequest request);
    }
}
