using System;
namespace Green.Services.AuthAPI.Models.Dto
{
	public class LoginResponseDto
	{
        public UserDto? UserDto { get; set; }

        public string? AccessToken { get; set; }
    }
}

