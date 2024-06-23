using WC.Library.Domain.Models;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public interface IEmployeeRegistrationManager
{
    Task<CreateResultModel> Register(
        EmployeeRegistrationModel registrationRequestModel,
        CancellationToken cancellationToken = default);
}