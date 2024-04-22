using FluentValidation;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services.Validators.RegistrationRequestModelValidator;

public class RegistrationRequestEmailValidator : AbstractValidator<RegistrationRequestModel>
{
    public RegistrationRequestEmailValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .Custom((email, context) =>
            {
                if (!RegistrationRequestEmailValidatorHelper.TryGetDomain(email, out var domain))
                {
                    context.AddFailure("Invalid email format or domain");
                    return;
                }

                var allowedDomains = new List<string?>
                {
                    "gmail.com",
                    "mail.ru",
                    "yahoo.com",
                    "hotmail.com",
                    "outlook.com"
                };

                if (domain != null && !allowedDomains.Contains(domain))
                {
                    context.AddFailure($"Invalid domain '{domain}'");
                }
            });
    }
}