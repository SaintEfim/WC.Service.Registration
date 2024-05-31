using Microsoft.Extensions.Logging;
using WC.Service.Registration.Data.PostgreSql.Context;
using WC.Service.Registration.Data.Repository;

namespace WC.Service.Registration.Data.PostgreSql.Repository;

public class EmployeeRegistrationRepository : EmployeeRegistrationRepository<RegistrationDbContext>
{
    public EmployeeRegistrationRepository(RegistrationDbContext context, ILogger<EmployeeRegistrationRepository> logger) :
        base(
            context, logger)
    {
    }
}