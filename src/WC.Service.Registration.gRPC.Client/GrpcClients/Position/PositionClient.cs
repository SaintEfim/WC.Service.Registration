using AutoMapper;
using Grpc.Net.Client;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.GrpcClients;
using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.gRPC.GrpcClients.Position;

public class PositionClient : IPositionClient
{
    private readonly PositionService.PositionServiceClient _client;
    private readonly IMapper _mapper;

    public PositionClient(IMapper mapper, IPositionClientConfiguration configuration)
    {
        _mapper = mapper;
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new PositionService.PositionServiceClient(channel);
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