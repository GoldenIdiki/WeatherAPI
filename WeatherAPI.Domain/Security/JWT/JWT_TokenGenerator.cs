using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeatherAPI.Domain.Settings;

namespace WeatherAPI.Domain.Security.JWT
{
    public class JWT_TokenGenerator : IJWT_TokenGenerator
    {
        private readonly JwtSettings _optionsMonitor;
        private readonly UserManager<AppUser> _userManager;
        public JWT_TokenGenerator(IOptionsMonitor<JwtSettings> optionsMonitor, UserManager<AppUser> userManager)
        {
            _optionsMonitor = optionsMonitor.CurrentValue;
            _userManager = userManager;
        }
        public async Task<string> GenerateToken(AppUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_optionsMonitor.Key);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, user.PhoneNumber),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }
                .Union(roleClaims)
                ),
                Expires = DateTime.UtcNow.AddHours(6),
                Issuer = _optionsMonitor.Issuer,
                Audience = _optionsMonitor.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
