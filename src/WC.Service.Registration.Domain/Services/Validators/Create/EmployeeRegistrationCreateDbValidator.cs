using FluentValidation;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.gRPC.Client.Clients;
using WC.Service.Registration.gRPC.Client.Models;
using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.Domain.Services.Validators.Create;

public class EmployeeRegistrationCreateDbValidator : AbstractValidator<EmployeeRegistrationModel>
{
    public EmployeeRegistrationCreateDbValidator(IGreeterPositionsClient greeterPositionsClient)
    {
        RuleFor(x => x)
            .CustomAsync(async (positionModel, context, cancellationToken) =>
            {
                var positions = await greeterPositionsClient.CheckPosition(new CheckPositionRequestModel
                {
                    Name = positionModel.Position
                }, cancellationToken);

                if (!positions.IsPositionExists)
                {
                    context.AddFailure(nameof(positionModel),
                        $"Position with this {positionModel.Name} already exists.");
                }
            });
    }
}