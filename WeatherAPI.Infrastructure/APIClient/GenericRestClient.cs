using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using WeatherAPI.Domain.Contracts.Infrastructure;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;
using WeatherAPI.Domain.Settings;

namespace WeatherAPI.Infrastructure.APIClient
{
    public class GenericRestClient : IGenericRestClient
    {
        private readonly WeatherAPISettings _config;
        private readonly RestClient _client;

        public GenericRestClient(IOptions<WeatherAPISettings> config)
        {
            _config = config.Value;
            _client = new RestClient(_config.BaseUrl);
        }
        public async Task<ServiceResponse<WeatherDTO>> GetWeatherDetails(WeatherRequest request)
        {
            var startDate = request.StartDate.ToString("yyyy-MM-dd");
            var endDate = request.EndDate.ToString("yyyy-MM-dd");
            var route = new RestRequest($"/{request.Location}/{startDate}/{endDate}" +
                $"?unitGroup=metric&include=current&key={_config.Key}&contentType=json");
            var response = await _client.ExecuteGetAsync<WeatherDTO>(route);
            if (!response.IsSuccessful)
            {
                var exceptionMessage = response.ErrorException.Message;
                throw new Exception(exceptionMessage);
            }
            var result = JsonConvert.DeserializeObject<WeatherDTO>(response.Content);
            return new ServiceResponse<WeatherDTO>
            {
                Data = result
            };
        }
    }
}
