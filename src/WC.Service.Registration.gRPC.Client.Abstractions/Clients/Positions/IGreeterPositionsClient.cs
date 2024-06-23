using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.gRPC.Client.Clients.Positions;

public interface IGreeterPositionsClient
{
    Task<CheckPositionResponseModel> CheckPosition(PositionRequestModel positionRequest,
        CancellationToken cancellationToken = default);
}