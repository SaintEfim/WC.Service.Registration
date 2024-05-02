using WC.Library.Domain.Services;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public interface IUserRegistrationManager : IDataManager<UserRegistrationModel>
{
    Task Register(
        RegistrationRequestModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}