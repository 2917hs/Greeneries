using System;
using Green.Services.AuthAPI.Models;

namespace Green.Services.AuthAPI.Service
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUser applicationUser);
	}
}

