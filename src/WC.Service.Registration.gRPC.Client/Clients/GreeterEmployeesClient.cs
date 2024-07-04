using Grpc.Net.Client;
using WC.Library.Domain.Models;
using WC.Service.Registration.Domain;
using WC.Service.Registration.gRPC.Client.Models.Employee;
using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client.Clients;

public class GreeterEmployeesClient : IGreeterEmployeesClient
{
    private readonly GreeterEmployees.GreeterEmployeesClient _client;
    private readonly IGreeterPositionsClient _greeterPositionsClient;

    public GreeterEmployeesClient(IEmployeesClientConfiguration configuration,
        IGreeterPositionsClient greeterPositionsClient)
    {
        _greeterPositionsClient = greeterPositionsClient;

        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterEmployees.GreeterEmployeesClient(channel);
    }

    public async Task<CreateResultModel> Create(EmployeeCreateModel entity,
        CancellationToken cancellationToken)
    {
        var position = await _greeterPositionsClient.SearchPosition(new SearchPositionRequestModel
        {
            Name = entity.Position
        }, cancellationToken);

        ArgumentNullException.ThrowIfNull(position);

        var createResult =
            await _client.CreateAsync(new EmployeeCreateRequest
            {
                Employee = new Employee
                {
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Patronymic = entity.Patronymic,
                    Email = entity.Email,
                    Password = entity.Password,
                    PositionId = position.Id.ToString()
                }
            }, cancellationToken: cancellationToken);

        return new CreateResultModel
        {
            Id = Guid.Parse(createResult.Id)
        };
    }
}