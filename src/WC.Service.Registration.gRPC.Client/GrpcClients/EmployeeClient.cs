using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using WC.Service.Registration.gRPC.Models;
using WC.Service.Registration.gRPC.Services;

namespace WC.Service.Registration.gRPC.GrpcClients;

public class EmployeeClient : IEmployeeRegistrationClient
{
    private readonly EmployeeService.EmployeeServiceClient _client;
    private readonly IMapper _mapper;

    public EmployeeClient(IConfiguration config, IMapper mapper)
    {
        var channel = GrpcChannel.ForAddress(config.GetValue<string>("GrpcSettings:EmployeeServiceUrl")!);
        _client = new EmployeeService.EmployeeServiceClient(channel);
        _mapper = mapper;
    }

    public async Task<List<EmployeeRegistrationClientModel>> Get(CancellationToken cancellationToken)
    {
        var responses = await _client.GetAsync(new Empty(), cancellationToken: cancellationToken);
        return _mapper.Map<List<EmployeeRegistrationClientModel>>(responses);
    }

    public async Task<CreateResultModel> Create(EmployeeRegistrationClientModel entity,
        CancellationToken cancellationToken)
    {
        var createResult =
            await _client.CreateAsync(_mapper.Map<Employee>(entity), cancellationToken: cancellationToken);
        return _mapper.Map<CreateResultModel>(createResult);
    }
}