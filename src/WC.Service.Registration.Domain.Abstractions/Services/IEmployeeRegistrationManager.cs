using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public interface IEmployeeRegistrationManager
{
    Task<EmployeeRegistrationModel> Register(
        EmployeeRegistrationModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}