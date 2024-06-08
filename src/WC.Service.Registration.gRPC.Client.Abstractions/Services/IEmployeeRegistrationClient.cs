using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.Services;

public interface IEmployeeRegistrationClient
{
    Task<List<EmployeeRegistrationClientModel>> Get(CancellationToken cancellationToken);

    Task<CreateResultModel> Create(EmployeeRegistrationClientModel entity, CancellationToken cancellationToken);
}