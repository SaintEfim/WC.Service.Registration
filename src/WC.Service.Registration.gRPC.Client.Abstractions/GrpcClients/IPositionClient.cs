using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.gRPC.Client.GrpcClients;

public interface IPositionClient
{
    Task<CheckPositionResponseModel> CheckPosition(PositionRequestModel positionRequest,
        CancellationToken cancellationToken = default);
}