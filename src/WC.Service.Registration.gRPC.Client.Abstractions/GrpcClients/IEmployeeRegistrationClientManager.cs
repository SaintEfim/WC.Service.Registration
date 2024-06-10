using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.GrpcClients;

public interface IEmployeeRegistrationClientManager
{
    Task<CreateResultModel> Create(EmployeeRegistrationClientModel entity, CancellationToken cancellationToken);
}