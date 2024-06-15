using FluentValidation;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Validators;

public class EmployeeRegistrationModelValidator : AbstractValidator<EmployeeRegistrationModel>
{
    public EmployeeRegistrationModelValidator()
    {
        // RuleFor(x => x.Email)
        //     .NotNull()
        //     .SetValidator(new EmailValidator());
        //
        // RuleFor(x => x.Password)
        //     .NotNull()
        //     .SetValidator(new PasswordValidator());
    }
}