using Google.Protobuf.WellKnownTypes;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.Services;

public interface IEmployeeRegistrationClient
{
    Task<List<EmployeeServiceClientModel>> Get(CancellationToken cancellationToken);

    Task<Empty> Create(EmployeeServiceClientModel entity, CancellationToken cancellationToken);
}