using WC.Library.Domain.Services;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services;

public interface IUserRegistrationManager : IDataManager<UserRegistrationModel>
{
    Task Register(
        RegistrationRequestModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}