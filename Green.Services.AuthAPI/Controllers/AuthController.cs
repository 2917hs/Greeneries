using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Green.Services.AuthAPI.Models.Dto;
using Green.Services.AuthAPI.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Green.Services.AuthAPI.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        protected ResponseDto responseDto;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
            responseDto = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
        {
            var message = await authService.Register(registrationDto);
            if (!string.IsNullOrEmpty(message))
            {
                responseDto.Message = message;
                responseDto.IsSuccess = false;
                return BadRequest(responseDto);
            }

            responseDto.IsSuccess = true;
            responseDto.Result = registrationDto;
            return Ok(responseDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var result = await authService.Login(loginRequestDto);
            if (result.UserDto is null)
            {
                responseDto.Message = "Invalid login attempted.";
                responseDto.IsSuccess = false;
                return BadRequest(responseDto);
            }

            responseDto.IsSuccess = true;
            responseDto.Result = result;
            return Ok(responseDto);
        }

        [HttpPost("assingRole")]
        public async Task<IActionResult> AssingRole([FromBody] RegistrationDto registrationDto)
        {
            var result = await authService.AssingRole(registrationDto.Email, registrationDto.Role);
            if (!result)
            {
                responseDto.Message = "Problem assignning role.";
                responseDto.IsSuccess = false;
                return BadRequest(responseDto);
            }

            responseDto.IsSuccess = true;
            responseDto.Result = result;
            return Ok(responseDto);
        }
    }
}

