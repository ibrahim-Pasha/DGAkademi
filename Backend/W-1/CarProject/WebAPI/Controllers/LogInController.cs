using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LogInController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        public LogInController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }


        [AllowAnonymous]
        [HttpPost("LogIn")]
        public IActionResult Authenticat(string UserName, string Password)
        {
            var token = jWTAuthenticationManager.Authenticat(UserName, Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}
