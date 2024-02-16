using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Green.Web.Models.Dto;
using Green.Web.Services;
using Green.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Green.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly ITokenProvider tokenProvider;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthController(
            IAuthService authService,
            ITokenProvider tokenProvider,
            IHttpContextAccessor httpContextAccessor )
        {
            this.authService = authService;
            this.tokenProvider = tokenProvider;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var result = await authService.LoginAsync(loginRequestDto);

            if (result is not null && result.IsSuccess)
            {
                var response = JsonConvert.DeserializeObject<LoginResponseDto>
                                                    (result.Result.ToString());

                tokenProvider.SetToken(response.AccessToken);

                //await AuthenticateUser(response);
                ViewData["IsAuthenticated"] = true;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", result.Message);
                return View(loginRequestDto);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = PopulateRoleDropdown();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationDto registrationDto)
        {
            var result = await authService.RegisterAsync(registrationDto);

            if (result is not null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(registrationDto.Role))
                {
                    registrationDto.Role = Role.Customer;
                }

                var assignRole = await authService.AssingRoleAsync(registrationDto);

                if (assignRole is not null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration successfull.";
                    return RedirectToAction(nameof(Login));
                }
            }

            ViewBag.Roles = PopulateRoleDropdown();

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        private List<SelectListItem> PopulateRoleDropdown()
        {
            return new List<SelectListItem>
            {
                new() { Text = Role.Admin, Value = Role.Admin},
                new() { Text = Role.Customer, Value = Role.Customer}
            };
        }

        private async Task AuthenticateUser(LoginResponseDto loginResponseDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(loginResponseDto.AccessToken);
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(
                new Claim(
                    JwtRegisteredClaimNames.Email,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value
                ));
            identity.AddClaim(
                new Claim(
                    JwtRegisteredClaimNames.Sub,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value
                ));
            identity.AddClaim(
                new Claim(
                    JwtRegisteredClaimNames.Name,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value
                ));
            identity.AddClaim(
                new Claim(
                    ClaimTypes.Name,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value
                ));

            var principal = new ClaimsPrincipal(identity);
            await AuthenticationHttpContextExtensions.
                SignInAsync(HttpContext, principal);
        }
    }
}

