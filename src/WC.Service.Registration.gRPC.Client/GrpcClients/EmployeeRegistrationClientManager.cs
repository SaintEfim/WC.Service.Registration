using AutoMapper;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.GrpcClients;

public class EmployeeRegistrationClientManager : IEmployeeRegistrationClientManager
{
    private readonly EmployeeService.EmployeeServiceClient _client;
    private readonly IMapper _mapper;

    public EmployeeRegistrationClientManager(IConfiguration config, IMapper mapper)
    {
        var channel = GrpcChannel.ForAddress(config.GetValue<string>("EmployeeService:url") ??
                                             throw new InvalidOperationException(
                                                 "Employee REST API service URL must be specified"));
        _client = new EmployeeService.EmployeeServiceClient(channel);
        _mapper = mapper;
    }

    public async Task<CreateResultModel> Create(EmployeeRegistrationClientModel entity,
        CancellationToken cancellationToken)
    {
        var createResult =
            await _client.CreateAsync(_mapper.Map<Employee>(entity), cancellationToken: cancellationToken);
        return _mapper.Map<CreateResultModel>(createResult);
    }
}