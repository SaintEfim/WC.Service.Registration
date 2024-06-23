using AutoMapper;
using Grpc.Net.Client;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.Clients.Positions;
using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.gRPC.Clients.Positions;

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

    public async Task<CheckPositionResponseModel> CheckPosition(PositionRequestModel positionRequest,
        CancellationToken cancellationToken)
    {
        var checkResult =
            await _client.CheckPositionExistsAsync(_mapper.Map<CheckPositionRequest>(positionRequest),
                cancellationToken: cancellationToken);

        return _mapper.Map<CheckPositionResponseModel>(checkResult);
    }
}