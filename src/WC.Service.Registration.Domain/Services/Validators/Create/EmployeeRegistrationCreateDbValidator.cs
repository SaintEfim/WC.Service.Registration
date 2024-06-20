using FluentValidation;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Validators.Create;

public class EmployeeRegistrationCreateDbValidator : AbstractValidator<EmployeeRegistrationModel>
{
    // public EmployeeRegistrationCreateDbValidator(IEmployeeRegistrationProvider positionProvider)
    // {
    //     RuleFor(x => x)
    //         .CustomAsync(async (positionModel, context, cancellationToken) =>
    //         {
    //             var positions = await positionProvider.Get(cancellationToken);
    //
    //             var duplicatePosition = positions.Any(x => x.Name == positionModel.Name);
    //
    //             if (duplicatePosition)
    //             {
    //                 context.AddFailure(nameof(PositionModel.Name),
    //                     $"Position with this {positionModel.Name} already exists.");
    //             }
    //         });
    // }
}