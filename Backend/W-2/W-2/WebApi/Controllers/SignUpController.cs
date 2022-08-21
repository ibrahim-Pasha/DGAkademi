using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private IUserService _UserService;
        public SignUpController(IUserService userService)
        {
            _UserService = userService;
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public string SiginUp(string name, string surName, string userName, string password)
        {
            if (userName != null || password != null)
            {
                _UserService.AddUser(name, surName, userName, password);
            }

            return name + " " + surName;

        }
    }
}

