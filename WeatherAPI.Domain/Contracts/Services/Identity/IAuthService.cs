using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;

namespace WeatherAPI.Domain.Contracts.Services.Identity
{
    public interface IAuthService
    {
        Task<ServiceResponse<AuthDTO>> Login(AuthRequest request);
    }
}
