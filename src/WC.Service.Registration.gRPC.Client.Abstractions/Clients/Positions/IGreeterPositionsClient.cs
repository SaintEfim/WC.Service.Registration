using WC.Service.Registration.gRPC.Client.Models;
using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client.Clients.Positions;

public interface IGreeterPositionsClient
{
    Task<CheckPositionResponseModel> CheckPosition(PositionRequestModel positionRequest,
        CancellationToken cancellationToken = default);
}