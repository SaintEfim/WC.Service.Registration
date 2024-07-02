using Grpc.Net.Client;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client.Clients;

public class GreeterPositionsClient : IGreeterPositionsClient
{
    private readonly GreeterPositions.GreeterPositionsClient _client;

    public GreeterPositionsClient(IPositionsClientConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterPositions.GreeterPositionsClient(channel);
    }

    public async Task<CheckPositionResponseModel> CheckPosition(CheckPositionRequestModel checkPositionRequest,
        CancellationToken cancellationToken)
    {
        var checkResult =
            await _client.CheckPositionExistsAsync(new CheckPositionRequest
            {
                Position = new Position
                {
                    Name = checkPositionRequest.Name
                }
            }, cancellationToken: cancellationToken);

        return new CheckPositionResponseModel
        {
            IsPositionExists = checkResult.IsPositionExists
        };
    }
}