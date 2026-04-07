using Blazilla;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Forms;
using SevDocs.Client.Providers;
using System.Runtime.CompilerServices;

namespace SevDocs.Client.Components
{
    public class SevFluentValidator : FluentValidator
    {
        public void AddApiErrors(ICollection<ApiError> apiErrors)
        {
            if (apiErrors.Count == 0)
                return;

            var result = new ValidationResult(apiErrors.Select(x => new ValidationFailure
            {
                ErrorCode = x.Code,
                PropertyName = x.Name,
                Severity = x.Severity != null ? Enum.Parse<Severity>(x.Severity) : default,
                ErrorMessage = x.Reason
            }));

            ApplyValidationResults(this, result);
        }

        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "ApplyValidationResults")]
        private extern static void ApplyValidationResults(FluentValidator @this, ValidationResult validationResults, FieldIdentifier? fieldIdentifier = null);
    }
}
