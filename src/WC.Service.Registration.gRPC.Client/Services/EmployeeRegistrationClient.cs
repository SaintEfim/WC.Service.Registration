using System.Globalization;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.Services;

public class EmployeeRegistrationClient : IEmployeeRegistrationClient
{
    private readonly EmployeeService.EmployeeServiceClient _client;

    public EmployeeRegistrationClient(IConfiguration config)
    {
        var channel = GrpcChannel.ForAddress(config.GetValue<string>("GrpcSettings:EmployeeServiceUrl")!);
        _client = new EmployeeService.EmployeeServiceClient(channel);
    }

    public async Task<string> RegisterEmployeeAsync(EmployeeRegistrationRequestModel user, CancellationToken cancellationToken)
    {
        var response = await _client.RegisterEmployeeAsync(new EmployeeRegistrationRequest
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            Password = user.Password,
            Role = user.Role,
            CreatedAt = user.CreatedAt.ToString(CultureInfo.InvariantCulture),
            UpdatedAt = user.UpdatedAt.ToString()
        }, cancellationToken: cancellationToken);
        
        return response.Message;
    }
}