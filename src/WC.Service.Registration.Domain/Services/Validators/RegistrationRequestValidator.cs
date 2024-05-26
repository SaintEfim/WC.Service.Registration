using FluentValidation;
using WC.Library.Domain.Services.Validators;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequestModel>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Email)
            .SetValidator(new EmailValidator())
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.Password)
            .SetValidator(new PasswordValidator())
            .When(x => !string.IsNullOrEmpty(x.Password));
    }
}