using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Security.JWT
{
    public interface IJWT_TokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }
}
