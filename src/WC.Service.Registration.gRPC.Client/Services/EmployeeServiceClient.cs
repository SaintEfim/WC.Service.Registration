using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.Services;

public class EmployeeServiceClient : IEmployeeRegistrationClient
{
    private readonly EmployeeService.EmployeeServiceClient _client;
    private readonly IMapper _mapper;

    public EmployeeServiceClient(IConfiguration config, IMapper mapper)
    {
        var channel = GrpcChannel.ForAddress(config.GetValue<string>("GrpcSettings:EmployeeServiceUrl")!);
        _client = new EmployeeService.EmployeeServiceClient(channel);
        _mapper = mapper;
    }

    public async Task<ICollection<EmployeeServiceClientModel>> Get(CancellationToken cancellationToken)
    {
        var responses = await _client.GetAsync(new Empty(), cancellationToken: cancellationToken);
        return _mapper.Map<List<EmployeeServiceClientModel>>(responses);
    }

    public async Task Create(EmployeeServiceClientModel entity, CancellationToken cancellationToken)
    {
        await _client.CreateAsync(_mapper.Map<Employee>(entity), cancellationToken: cancellationToken);
    }

    public Task<EmployeeServiceClientModel?> GetOneById(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(EmployeeServiceClientModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}