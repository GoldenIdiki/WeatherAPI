using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Exceptions
{
    public class NotImplementedException : ApplicationException
    {
        public NotImplementedException(string message) : base(message)
        {

        }
    }
}
