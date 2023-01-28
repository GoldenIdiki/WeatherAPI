using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Exceptions
{
    public class KeyNotFoundException : ApplicationException
    {
        public KeyNotFoundException(string message) : base(message)
        {

        }
    }
}
