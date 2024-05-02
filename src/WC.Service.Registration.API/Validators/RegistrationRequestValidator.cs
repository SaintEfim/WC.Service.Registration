using FluentValidation;
using WC.Service.Registration.API.Models;

namespace WC.Service.Registration.API.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequestDto>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}