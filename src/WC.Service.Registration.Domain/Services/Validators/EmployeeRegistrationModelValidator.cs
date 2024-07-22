using FluentValidation;
using WC.Library.Employee.Shared.Validators;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Validators;

public class EmployeeRegistrationModelValidator : AbstractValidator<EmployeeRegistrationModel>
{
    public EmployeeRegistrationModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .SetValidator(new NameValidator(nameof(EmployeeRegistrationModel.Name)));

        RuleFor(x => x.Surname)
            .NotNull()
            .SetValidator(new NameValidator(nameof(EmployeeRegistrationModel.Surname)));

        RuleFor(x => x.Patronymic)
            .SetValidator(new NameValidator(nameof(EmployeeRegistrationModel.Patronymic))!)
            .When(x => !string.IsNullOrEmpty(x.Patronymic));

        RuleFor(x => x.Email)
            .NotNull()
            .SetValidator(new EmailValidator(nameof(EmployeeRegistrationModel.Email)));

        RuleFor(x => x.Password)
            .NotNull()
            .SetValidator(new PasswordValidator(nameof(EmployeeRegistrationModel.Password)));

        RuleFor(x => x.Position)
            .NotNull()
            .SetValidator(new PositionValidator(nameof(EmployeeRegistrationModel.Position)));
    }
}
