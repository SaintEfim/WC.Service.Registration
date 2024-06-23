using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client.Clients;

public interface IGreeterPositionsClient
{
    Task<CheckPositionResponseModel> CheckPosition(CheckPositionRequestModel checkPositionRequest,
        CancellationToken cancellationToken = default);
}