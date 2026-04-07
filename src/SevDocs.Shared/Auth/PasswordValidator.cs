using FluentValidation;

namespace SevDocs.Shared.Auth
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
            : this(string.Empty)
        {
        }

        public PasswordValidator(string propertyName)
        {
            RuleFor(password => password)
                .NotEmpty()
                    .OverridePropertyName(propertyName)
                .MinimumLength(6)
                    .OverridePropertyName(propertyName)
                .MaximumLength(256)
                    .OverridePropertyName(propertyName)
                .Must(password => password.Any(char.IsUpper))
                    .OverridePropertyName(propertyName)
                    .WithMessage("'{PropertyName}' must contain at least one uppercase letter.")
                .Must(password => password.Any(char.IsLower))
                    .OverridePropertyName(propertyName)
                    .WithMessage("'{PropertyName}' must contain at least one lowercase letter.")
                .Must(password => password.Any(char.IsNumber))
                    .OverridePropertyName(propertyName)
                    .WithMessage("'{PropertyName}' must contain at least one number.")
                .Must(password => !password.All(char.IsLetterOrDigit))
                    .OverridePropertyName(propertyName)
                    .WithMessage("'{PropertyName}' must contain at least one non-alphanumeric character.");
        }
    }
}
