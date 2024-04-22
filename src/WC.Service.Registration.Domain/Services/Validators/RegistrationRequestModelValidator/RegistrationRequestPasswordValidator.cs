using FluentValidation;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services.Validators.RegistrationRequestModelValidator;

public class RegistrationRequestPasswordValidator : AbstractValidator<RegistrationRequestModel>
{
    public RegistrationRequestPasswordValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(8, 64).WithMessage("Password must be between 8 and 64 characters")
            .Matches(@"(?=.*\d)").WithMessage("At least one digit (0-9)")
            .Matches("(?=.*[a-z])").WithMessage("At least one lowercase letter (a-z)")
            .Matches("(?=.*[A-Z])").WithMessage("At least one uppercase letter (A-Z)")
            .Matches(@"(?!.*\s)").WithMessage("No whitespace characters (spaces, tabs, etc.)");
    }
}