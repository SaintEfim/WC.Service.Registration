using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public interface IEmployeeRegistrationManager
{
    Task<Guid> Register(
        EmployeeRegistrationModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}