using FluentValidation;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;
using System.Text.RegularExpressions;

namespace KelimeDefteriAPI.Services.Validations
{
    public class RecordValidator : AbstractValidator<RecordViewModel>, IDisposable
    {
        private bool disposedValue;

        public RecordValidator()
        {
            RuleFor(rec => rec.Words.Count)
                .GreaterThanOrEqualTo(1).WithMessage("Record count must be longer than or equal to 1.");

            RuleFor(rec => rec.Created)
                .Matches(new Regex("(\\d){2}[.-/](\\d){2}[.-/](\\d){4}")); // It matches dd-MM-YYYY or dd.MM.YYYY or dd/MM/YYYY

            RuleForEach(rec => rec.Words)
                .SetValidator(new WordValidator());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RecordValidator()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
