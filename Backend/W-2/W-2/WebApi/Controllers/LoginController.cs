using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WebApi.Models;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _UserService;
        private IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _UserService = userService;
            _configuration = configuration;

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = _UserService.AuthenticateUser(loginModel.Username, loginModel.Password);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);

            }
            return BadRequest(new { message = "Kullancı adı veya şifre yalnış girdiniz" });
        }

        private object Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Surname,user.SurName),
                new Claim(ClaimTypes.Role,user.Role),

            };
            var token = new JwtSecurityToken
                (
                _configuration["Jwt:Issuer"],
               _configuration["Jwt:Audience"],
               claims,
               expires: DateTime.Now.AddDays(14),
               signingCredentials: credentials
               );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
