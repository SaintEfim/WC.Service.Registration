using AutoMapper;
using Grpc.Net.Client;
using WC.Library.Domain.Models;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.Clients.Employees;
using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.gRPC.Clients.Employees;

public class GreeterEmployeesClient : IGreeterEmployeesClient
{
    private readonly GreeterEmployees.GreeterEmployeesClient _client;
    private readonly IMapper _mapper;

    public GreeterEmployeesClient(IMapper mapper, IEmployeesClientConfiguration configuration)
    {
        _mapper = mapper;

        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterEmployees.GreeterEmployeesClient(channel);
    }

    public async Task<CreateResultModel> Create(EmployeeCreateModel entity,
        CancellationToken cancellationToken)
    {
        var createResult =
            await _client.CreateAsync(_mapper.Map<EmployeeCreateRequest>(entity), cancellationToken: cancellationToken);

        return _mapper.Map<CreateResultModel>(createResult);
    }
}