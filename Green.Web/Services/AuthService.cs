using System;
using Green.Web.Models.Dto;

namespace Green.Web.Services
{
    public class AuthService : IAuthService
	{
        private readonly IBaseService baseService;

		public AuthService(IBaseService baseService)
		{
            this.baseService = baseService;
		}

        public async Task<ResponseDto?> AssingRoleAsync(RegistrationDto registrationDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.POST,
                Url = $"{Utility.StaticDetails.AuthApiBase}/api/Auth/assingRole",
                Data = registrationDto
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.POST,
                Url = $"{Utility.StaticDetails.AuthApiBase}/api/Auth/login",
                Data = loginRequestDto
            });
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationDto registrationDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.POST,
                Url = $"{Utility.StaticDetails.AuthApiBase}/api/Auth/register",
                Data = registrationDto
            });
        }
    }
}

