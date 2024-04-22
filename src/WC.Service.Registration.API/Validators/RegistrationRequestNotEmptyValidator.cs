using FluentValidation;
using WC.Service.Registration.API.Models;

namespace WC.Service.Registration.API.Validators;

public class RegistrationRequestNotEmptyValidator : AbstractValidator<RegistrationRequestDto>
{
    public RegistrationRequestNotEmptyValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}