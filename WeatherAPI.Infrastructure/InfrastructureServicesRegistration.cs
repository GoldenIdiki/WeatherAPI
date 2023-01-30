using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherAPI.Domain.Contracts.Infrastructure;
using WeatherAPI.Domain.Settings;
using WeatherAPI.Infrastructure.APIClient;

namespace WeatherAPI.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WeatherAPISettings>(configuration.GetSection("WeatherAPISettings"));
            services.AddScoped<IGenericRestClient, GenericRestClient>();
            return services;
        }
    }
}