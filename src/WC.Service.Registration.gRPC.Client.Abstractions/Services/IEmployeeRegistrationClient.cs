using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.Services;

public interface IEmployeeRegistrationClient
{
    Task<string> RegisterEmployeeAsync(EmployeeRegistrationRequestModel user, CancellationToken cancellationToken);
}