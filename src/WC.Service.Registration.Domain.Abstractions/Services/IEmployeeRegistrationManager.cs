using WC.Service.Authentication.gRPC.Client.Models;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public interface IEmployeeRegistrationManager
{
    Task<LoginResponseModel> Register(
        EmployeeRegistrationModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}
