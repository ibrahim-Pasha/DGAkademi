using Entity.Constants;
using FluentValidation;
using WebApi.Models;

namespace WebApi.ValidationRules
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Username).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(l => l.Password).NotEmpty().WithMessage(Messages.NotEmpty);
        }
    }
}
