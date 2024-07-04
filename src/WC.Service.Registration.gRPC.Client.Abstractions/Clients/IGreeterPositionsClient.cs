using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client.Clients;

public interface IGreeterPositionsClient
{
    Task<SearchPositionResponseModel?> SearchPosition(SearchPositionRequestModel request,
        CancellationToken cancellationToken);
}