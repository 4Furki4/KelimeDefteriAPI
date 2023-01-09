using FluentValidation;
using KelimeDefteriAPI.Context.ViewModels;

namespace KelimeDefteriAPI.Services.Validations
{
    public class WordValidator : AbstractValidator<WordViewModel>
    {
        public WordValidator()
        {
            RuleFor(word => word.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MinimumLength(1).WithMessage("Name must be longer than 1 characters");

            RuleFor(word => word.Definitions.Count)
                .GreaterThanOrEqualTo(1).WithMessage("Definition count must be longer than or equal to 1.");
            
            RuleForEach(word => word.Definitions)
                .SetValidator(new DefinitionValidator());
        }
    }
}
