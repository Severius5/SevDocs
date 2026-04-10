using FluentValidation;
using SevDocs.Shared.Auth;

namespace SevDocs.Features.Auth.Login
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);

            RuleFor(x => x.Password)
                .SetValidator(new PasswordValidator(nameof(LoginModel.Password)));
        }
    }
}
