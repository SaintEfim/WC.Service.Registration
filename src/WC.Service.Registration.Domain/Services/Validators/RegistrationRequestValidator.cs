using FluentValidation;
using WC.Library.Domain.Services.Validators;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequestModel>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Email)
            .SetValidator(new EmailValidator());
        RuleFor(x => x.Password)
            .SetValidator(new PasswordValidator());
    }
}