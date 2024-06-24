using AutoMapper;
using Grpc.Net.Client;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client.Clients;

public class GreeterPositionsClient : IGreeterPositionsClient
{
    private readonly GreeterPositions.GreeterPositionsClient _client;
    private readonly IMapper _mapper;

    public GreeterPositionsClient(IMapper mapper, IPositionsClientConfiguration configuration)
    {
        _mapper = mapper;

        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterPositions.GreeterPositionsClient(channel);
    }

    public async Task<CheckPositionResponseModel> CheckPosition(CheckPositionRequestModel checkPositionRequest,
        CancellationToken cancellationToken)
    {
        var checkResult =
            await _client.CheckPositionExistsAsync(_mapper.Map<CheckPositionRequest>(checkPositionRequest),
                cancellationToken: cancellationToken);

        return new CheckPositionResponseModel
        {
            IsPositionExists = checkResult.IsPositionExists
        };
    }
}