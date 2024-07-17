using FluentValidation;
using WC.Service.Employees.gRPC.Client.Clients;
using WC.Service.Employees.gRPC.Client.Models.Employee.DoesEmployeeWithEmailExist;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Validators.Create;

public class EmployeeRegistrationCreateDbValidator : AbstractValidator<EmployeeRegistrationModel>
{
    public EmployeeRegistrationCreateDbValidator(IGreeterEmployeesClient employeesClient)
    {
        RuleFor(x => x.Email)
            .CustomAsync(async (email, context, cancellationToken) =>
            {
                var response = await employeesClient.DoesEmployeeWithEmailExist(
                    new DoesEmployeeWithEmailExistRequestModel
                    {
                        Email = email
                    }, cancellationToken);

                if (response.Exists)
                    context.AddFailure(nameof(EmployeeRegistrationModel.Email),
                        "An employee with this email already exists.");
            });
    }
}