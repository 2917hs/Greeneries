﻿using System;
namespace Green.Web.Models.Dto
{
	public class RegistrationDto
	{
        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Role { get; set; }
    }
}

