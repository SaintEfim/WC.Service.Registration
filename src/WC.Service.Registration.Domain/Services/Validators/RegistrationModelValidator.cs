using FluentValidation;
using WC.Library.Domain.Validators;

namespace WC.Service.Registration.Domain.Services.Validators;

public class RegistrationModelValidator
    : AbstractValidator<RegistrationCreatePayloadModel>,
        IDomainCreateValidator
{
    public RegistrationModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Surname)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.PositionId)
            .NotEmpty();
    }
}
