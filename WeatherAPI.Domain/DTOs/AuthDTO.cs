namespace WeatherAPI.Domain.DTOs
{
    public class AuthDTO
    {
        public AppUserDTO AppUser { get; set; }
        public TokenDTO Token { get; set; }
    }

    public class AppUserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class TokenDTO
    {
        public string BearerToken { get; set; }
    }
}
