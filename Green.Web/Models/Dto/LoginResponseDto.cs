using System;
namespace Green.Web.Models.Dto
{
	public class LoginResponseDto
	{
        public UserDto? UserDto { get; set; }

        public string? AccessToken { get; set; }
    }
}

