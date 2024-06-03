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

    public async Task<EmployeeServiceClientModel?> GetOneById(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _client.GetOneByIdAsync(new EmployeeId { Id = id.ToString() },
            cancellationToken: cancellationToken);
        return _mapper.Map<EmployeeServiceClientModel>(response);
    }

    public async Task Update(EmployeeServiceClientModel entity, CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(_mapper.Map<Employee>(entity), cancellationToken: cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        await _client.DeleteAsync(new EmployeeId { Id = id.ToString() },
            cancellationToken: cancellationToken);
    }
}