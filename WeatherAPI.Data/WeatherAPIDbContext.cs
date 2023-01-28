using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data.Configurations;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}