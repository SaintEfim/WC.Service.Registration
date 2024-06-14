using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.GrpcClients;

public interface IEmployeeClientManager
{
    Task<CreateResultModel> Create(EmployeeCreateModel entity, CancellationToken cancellationToken);
}