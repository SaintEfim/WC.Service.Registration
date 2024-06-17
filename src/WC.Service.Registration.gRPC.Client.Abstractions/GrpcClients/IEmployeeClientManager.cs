using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.gRPC.Client.GrpcClients;

public interface IEmployeeClientManager
{
    Task<CreateResultModel> Create(EmployeeCreateModel entity, CancellationToken cancellationToken);
}