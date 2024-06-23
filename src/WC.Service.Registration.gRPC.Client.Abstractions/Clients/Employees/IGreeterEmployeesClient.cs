using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.gRPC.Client.Clients.Employees;

public interface IGreeterEmployeesClient
{
    Task<CreateResultModel> Create(EmployeeCreateModel entity, CancellationToken cancellationToken = default);
}