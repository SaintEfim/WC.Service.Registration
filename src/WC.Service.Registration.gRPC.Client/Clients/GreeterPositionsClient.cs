using Grpc.Net.Client;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client.Clients;

public class GreeterPositionsClient : IGreeterPositionsClient
{
    private readonly GreeterPositions.GreeterPositionsClient _client;

    public GreeterPositionsClient(IEmployeesClientConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterPositions.GreeterPositionsClient(channel);
    }

    public async Task<SearchPositionResponseModel?> SearchPosition(SearchPositionRequestModel request,
        CancellationToken cancellationToken)
    {
        var searchResult =
            await _client.SearchPositionAsync(new SearchPositionRequest
            {
                Position = new Position
                {
                    Name = request.Name
                }
            }, cancellationToken: cancellationToken);

        return new SearchPositionResponseModel
        {
            Id = Guid.Parse(searchResult.Id)
        };
    }
}