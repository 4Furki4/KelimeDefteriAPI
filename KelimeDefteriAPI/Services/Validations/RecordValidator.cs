using FluentValidation;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;
using System.Text.RegularExpressions;

namespace KelimeDefteriAPI.Services.Validations
{
    public class RecordValidator : AbstractValidator<RecordViewModel>
    {
        public RecordValidator()
        {
            RuleFor(rec => rec.Words.Count)
                .GreaterThanOrEqualTo(1).WithMessage("Record count must be longer than or equal to 1.");

            RuleFor(rec => rec.Created)
                .Matches(new Regex("/(\\d){2}[.-\\/](\\d){2}[.-\\/](\\d){4}/gi")); // It matches dd-MM-YYYY or dd.MM.YYYY or dd/MM/YYYY

            RuleForEach(rec => rec.Words)
                .SetValidator(new WordValidator());
        }
    }
}
