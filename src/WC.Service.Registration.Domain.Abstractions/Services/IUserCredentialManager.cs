using WC.Library.Domain.Services;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services;

public interface IUserCredentialManager : IDataManager<UserCredentialModel>
{
    Task Register(
        RegistrationRequestModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}