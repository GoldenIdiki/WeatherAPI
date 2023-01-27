using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.RequestPayloads
{
    public class AuthRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
