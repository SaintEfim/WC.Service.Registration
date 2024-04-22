using FluentValidation;
using Service.Authify.Domain.Services.Validators;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services.Validators.RegistrationRequestModelValidator;

public class RegistrationRequestEmailValidator : AbstractValidator<RegistrationRequestModel>
{
    public RegistrationRequestEmailValidator()
    {
        RuleFor(x => x.Email)
            .SetValidator(new EmailValidator());
    }
}