using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Domain;
using WeatherAPI.Domain.Contracts.Services.Identity;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.Enums;
using WeatherAPI.Domain.Exceptions;
using WeatherAPI.Domain.RequestPayloads;
using WeatherAPI.Domain.Response.BaseResponse;
using WeatherAPI.Domain.Security.JWT;
using UnauthorizedAccessException = WeatherAPI.Domain.Exceptions.UnauthorizedAccessException;

namespace WeatherAPI.Data.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IJWT_TokenGenerator _tokenGenerator;

        public AuthService(IMapper mapper, IJWT_TokenGenerator tokenGenerator,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<AuthDTO>> Login(AuthRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            
            if (user == null)
            {
                throw new BadRequestException($"User with {request.UserName} does not exist");
            }

            var loggedInUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            if (loggedInUser != null)
            {
                if (loggedInUser.Id != user.Id)
                {
                    throw new UnauthorizedAccessException($"You're not authorized to view this resource");
                }
            }
            await _signInManager.SignOutAsync();

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InternalServerErrorException($"Something went wrong");
            }

            var getToken = await _tokenGenerator.GenerateToken(user);

            var token = new TokenDTO
            {
                BearerToken = getToken,
            };
            var appUser = _mapper.Map<AppUserDTO>(user);
            var loggedInUserDetailsToSend = new AuthDTO
            {
                Token = token,
                AppUser = appUser
            };
            var dataToSend = new ServiceResponse<AuthDTO>
            {
                Data = loggedInUserDetailsToSend
            };

            return dataToSend;
        }

        public async Task<ServiceResponse<RegistrationDTO>> CreateAccount(RegistrationRequest request)
        {
            var checkUser = await _userManager.Users.Where(x => x.Email == request.Email || x.PhoneNumber == request.PhoneNumber).FirstOrDefaultAsync();
            if (checkUser != null)
            {
                throw new BadRequestException("Account with either email or phone number already exists. Please proceed to login");
            }

            // map request to AppUser
            AppUser newUser = _mapper.Map<AppUser>(request);
            newUser.UserName = request.Email;

            // save newUser to db
            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                throw new InternalServerErrorException(string.Join($"{Environment.NewLine}", result.Errors));
            }
            await _userManager.AddToRoleAsync(newUser, Roles.Administrator.ToString());

            var dataToReturn = _mapper.Map<RegistrationDTO>(request);
            return new ServiceResponse<RegistrationDTO>
            {
                Data = dataToReturn
            };
        }
    }
}
