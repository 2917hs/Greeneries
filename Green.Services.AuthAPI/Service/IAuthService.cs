using System;
using Green.Services.AuthAPI.Models.Dto;

namespace Green.Services.AuthAPI.Service
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationDto registrationDto);

		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

		Task<bool> AssingRole(string email, string roleName);
	}
}

