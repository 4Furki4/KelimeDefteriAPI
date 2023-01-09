using FluentValidation;
using KelimeDefteriAPI.Context.ViewModels;

namespace KelimeDefteriAPI.Services.Validations
{
    public class DefinitionValidator : AbstractValidator<DefinitionViewModel>
    {
        public DefinitionValidator()
        {
            RuleFor(def => def.definition)
                .NotEmpty().WithMessage("Definition must not be empty!")
                .NotNull().WithMessage("Definition must not be null!")
                .MinimumLength(2).WithMessage("Definition must be longer than 2 characters!");

            RuleFor(def => def.definitionType)
                .NotEmpty().WithMessage("Definition type must not be empty!")
                .NotNull().WithMessage("Definition type must not be null!")
                .MinimumLength(2).WithMessage("Definition type must be longer than 2 characters!");
        }
    }
}
