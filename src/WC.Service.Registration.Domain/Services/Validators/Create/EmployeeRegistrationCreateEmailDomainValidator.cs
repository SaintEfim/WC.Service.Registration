using FluentValidation;
using WC.Service.EmailDomains.gRPC.Client.Clients;
using WC.Service.EmailDomains.gRPC.Client.Models.DoesEmailDomainWithDomainNameExist;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Validators.Create;

public sealed class EmployeeRegistrationCreateEmailDomainValidator : AbstractValidator<EmployeeRegistrationModel>
{
    public EmployeeRegistrationCreateEmailDomainValidator(
        IGreeterEmailDomainsClient emailDomainsClient)
    {
        RuleFor(x => x.Email)
            .CustomAsync(async (
                email,
                context,
                cancellationToken) =>
            {
                var domain = email.Split('@')[1];

                var domainResponse = await emailDomainsClient.DoesEmailDomainWithDomainNameExist(
                    new DoesEmailDomainWithDomainNameExistRequestModel { DomainName = domain }, cancellationToken);

                if (!domainResponse.Exists)
                {
                    context.AddFailure(nameof(EmployeeRegistrationModel.Email), "The email domain does not exist.");
                }
            });
    }
}
