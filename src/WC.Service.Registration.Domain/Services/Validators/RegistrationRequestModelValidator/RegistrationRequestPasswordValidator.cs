using FluentValidation;
using Service.Authify.Domain.Services.Validators;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services.Validators.RegistrationRequestModelValidator;

public class RegistrationRequestPasswordValidator : AbstractValidator<RegistrationRequestModel>
{
    public RegistrationRequestPasswordValidator()
    {
        RuleFor(x => x.Password)
            .SetValidator(new PasswordValidator());
    }
}