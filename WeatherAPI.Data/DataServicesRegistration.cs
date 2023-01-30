using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherAPI.Data.Services.Weather;
using WeatherAPI.Domain.Contracts.Services.Weather;

namespace WeatherAPI.Data
{
    public static class DataServicesRegistration
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WeatherAPIDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));

            
            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }
    }
}
