using Entity.Constants;
using FluentValidation;
using WebApi.Models;

namespace WebApi.ValidationRules
{
    public class SignUpValidator : AbstractValidator<SignUpModel>
    {
        public SignUpValidator()
        {
            RuleFor(s => s.Username).MinimumLength(5).WithMessage(Messages.UserNameLenth);
            RuleFor(s => s.Username).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.Password).MinimumLength(8).WithMessage(Messages.PasswordLenth);
            RuleFor(s => s.Password).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.Name).MinimumLength(3).WithMessage(Messages.Name_SurNameLenth);
            RuleFor(s => s.Name).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.SurName).MinimumLength(3).WithMessage(Messages.Name_SurNameLenth);
            RuleFor(s => s.SurName).NotEmpty().WithMessage(Messages.NotEmpty);
        }
    }
}
