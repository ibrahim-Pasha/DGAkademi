using Entity;
using Entity.Constants;
using FluentValidation;

namespace WebApi.ValidationRules
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Id).Empty().WithMessage(Messages.Empty);
            RuleFor(m => m.Name).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(m => m.Type).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(m => m.Producer).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(m => m.Description).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(m => m.Duration).GreaterThan(0).WithMessage(Messages.GreaterThen0);
        }
    }
}
