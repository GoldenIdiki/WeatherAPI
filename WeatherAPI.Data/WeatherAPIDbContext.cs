using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Domain;

namespace WeatherAPI.Data
{
    public class WeatherAPIDbContext : IdentityDbContext<AppUser>
    {
        private readonly DbContextOptions<WeatherAPIDbContext> _options;

        public WeatherAPIDbContext(DbContextOptions<WeatherAPIDbContext> options) : base(options)
        {
            _options = options;
        }
    }
}