using WC.Service.Authentication.gRPC.Client.Models;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public interface IRegistrationManager
{
    Task<AuthenticationLoginResponseModel?> Register(
        RegistrationModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}
