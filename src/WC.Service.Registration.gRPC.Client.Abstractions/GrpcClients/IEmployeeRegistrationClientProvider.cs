using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.GrpcClients;

public interface IEmployeeRegistrationClientProvider
{
    Task<List<EmployeeRegistrationClientModel>> Get(CancellationToken cancellationToken);
}