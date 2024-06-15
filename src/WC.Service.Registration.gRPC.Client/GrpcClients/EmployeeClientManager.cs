using AutoMapper;
using Grpc.Net.Client;
using WC.Library.Domain.Models;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.GrpcClients;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.GrpcClients;

public class EmployeeClientManager : IEmployeeClientManager
{
    private readonly EmployeeService.EmployeeServiceClient _client;
    private readonly IMapper _mapper;

    public EmployeeClientManager(IMapper mapper, IEmployeeClientConfiguration configuration)
    {
        _mapper = mapper;

        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new EmployeeService.EmployeeServiceClient(channel);
    }

    public async Task<CreateResultModel> Create(EmployeeCreateModel entity,
        CancellationToken cancellationToken)
    {
        var createResult =
            await _client.CreateAsync(_mapper.Map<EmployeeCreateRequest>(entity), cancellationToken: cancellationToken);
        return _mapper.Map<CreateResultModel>(createResult);
    }
}