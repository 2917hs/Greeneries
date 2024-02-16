using System;
using Green.Web.Models.Dto;

namespace Green.Web.Services
{
	public interface IAuthService
	{
		Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);

        Task<ResponseDto?> RegisterAsync(RegistrationDto registrationDto );

        Task<ResponseDto?> AssingRoleAsync(RegistrationDto registrationDto);
    }
}

