using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Response.BaseResponse
{
    public class ServiceResponse<TResponse>
    {
        public ServiceResponse()
        {
            Code = $"{(int)HttpStatusCode.OK}";
            ShortDescription = "Operation was successful!";
        }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public TResponse Data { get; set; }
    }
}
