using Entity;
using Entity.Constants;
using FluentValidation;

namespace WebApi.ValidationRules
{
    public class SeriesValidator:AbstractValidator<Series>
    {
        public SeriesValidator()
        {
            RuleFor(s => s.Id).Empty().WithMessage(Messages.Empty);
            RuleFor(s => s.Name).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.Type).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.Producer).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.Description).NotEmpty().WithMessage(Messages.NotEmpty);       
            RuleFor(s => s.Duration).GreaterThan(0).WithMessage(Messages.GreaterThen0);
            RuleFor(s => s.Pisodes).GreaterThan(0).WithMessage(Messages.GreaterThen0);
        }
    }
}
