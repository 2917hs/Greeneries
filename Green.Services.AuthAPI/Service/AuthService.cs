using System;
using Green.Services.AuthAPI.Data;
using Green.Services.AuthAPI.Models;
using Green.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace Green.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public AuthService(ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssingRole(string email, string roleName)
        {
            var user = applicationDbContext.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower().Equals(email.ToLower()));
            if (user is null)
            {
                return false;
            }

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            await userManager.AddToRoleAsync(user, roleName);
            return true;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var validateUser = applicationDbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower().Equals(loginRequestDto.UserName.ToLower()));
            if (validateUser is null)
            {
                return new LoginResponseDto();
            }

            var isAuthenticated = await userManager.CheckPasswordAsync(validateUser, loginRequestDto.Password);
            if (!isAuthenticated)
            {
                return new LoginResponseDto();
            }

            var user = new UserDto
            {
                Email = validateUser.Email,
                Id = validateUser.Id,
                Name = validateUser.Name,
                PhoneNumber = validateUser.PhoneNumber
            };

            var response = new LoginResponseDto { UserDto = user, AccessToken = jwtTokenGenerator.GenerateToken(validateUser) };

            return response;
        }

        public async Task<string> Register(RegistrationDto registrationDto)
        {
            string resultMessage = string.Empty;

            try
            {
                var result = await userManager.CreateAsync(
                                                new ApplicationUser
                                                {
                                                    UserName = registrationDto.Email,
                                                    Email = registrationDto.Email,
                                                    NormalizedEmail = registrationDto.Email.ToUpper(),
                                                    Name = registrationDto.Name,
                                                    PhoneNumber = registrationDto.PhoneNumber
                                                },
                                                registrationDto.Password);
                if (result.Succeeded)
                {
                    var fetchUser = applicationDbContext.ApplicationUsers.First(u => u.UserName.Equals(registrationDto.Email));

                    var user = new UserDto
                    {
                        Email = fetchUser.Email,
                        Id = fetchUser.Id,
                        Name = fetchUser.Name,
                        PhoneNumber = fetchUser.PhoneNumber
                    };
                }
                else
                {
                    resultMessage = result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }
            return resultMessage;
        }
    }
}

