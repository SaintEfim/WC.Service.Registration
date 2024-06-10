using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.GrpcClients;

public class EmployeeRegistrationClientProvider : IEmployeeRegistrationClientProvider
{
    private readonly EmployeeService.EmployeeServiceClient _client;
    private readonly IMapper _mapper;

    public EmployeeRegistrationClientProvider(IConfiguration config, IMapper mapper)
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
}