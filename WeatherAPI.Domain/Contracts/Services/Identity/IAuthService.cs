using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;

namespace WeatherAPI.Domain.Contracts.Services.Identity
{
    public interface IAuthService
    {
        Task<ServiceResponse<AuthDTO>> Login(AuthRequest request);
        Task<ServiceResponse<RegistrationDTO>> CreateAccount(RegistrationRequest request);
    }
}
