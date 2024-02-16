using System;
using Microsoft.AspNetCore.Identity;

namespace Green.Services.AuthAPI.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? Name { get; set; }
	}
}

