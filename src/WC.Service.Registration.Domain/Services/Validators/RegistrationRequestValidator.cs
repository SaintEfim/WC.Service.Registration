using FluentValidation;
using WC.Library.Domain.Services.Validators;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequestModel>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .SetValidator(new EmailValidator());
        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .SetValidator(new PasswordValidator());
    }
}