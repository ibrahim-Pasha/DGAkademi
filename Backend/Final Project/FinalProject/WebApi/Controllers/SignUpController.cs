using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.ValidationRules;

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
        public IActionResult SiginUp(SignUpModel signUpModel)
        {
            return AddUser(signUpModel);
        }

        /// <summary>
        /// Create new User and save it in db
        /// </summary>
        /// <param name="signUpModel">User information (UserName,pass,name,surname)</param>
        /// <returns></returns>
        private IActionResult AddUser(SignUpModel signUpModel)
        {
            SignUpValidator SV = new SignUpValidator();
            ValidationResult result = SV.Validate(signUpModel);
            if (result.IsValid)
            {
                _UserService.AddUser(signUpModel.Name, signUpModel.SurName, signUpModel.Username, signUpModel.Password);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    return BadRequest(item.PropertyName + " : " + item.ErrorMessage);
                }
            }
            return Ok();
        }
    }
}