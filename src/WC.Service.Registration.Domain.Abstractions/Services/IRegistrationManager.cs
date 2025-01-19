using WC.Service.Authentication.gRPC.Client.Models;

namespace WC.Service.Registration.Domain.Services;

public interface IRegistrationManager
{
    Task<AuthenticationLoginResponseModel> Register(
        RegistrationCreatePayloadModel registrationCreatePayloadRequestModel,
        bool withAuthentication = true,
        CancellationToken cancellationToken = default);
}
