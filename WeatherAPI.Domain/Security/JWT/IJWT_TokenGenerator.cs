namespace WeatherAPI.Domain.Security.JWT
{
    public interface IJWT_TokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }
}
