using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Repository;
using WC.Service.Registration.Data.Models;

namespace WC.Service.Registration.Data.Repository;

public class EmployeeRegistrationRepository<TDbContext> :
    RepositoryBase<EmployeeRegistrationRepository<TDbContext>, TDbContext, EmployeeRegistrationEntity>,
    IEmployeeRegistrationRepository
    where TDbContext : DbContext
{
    protected EmployeeRegistrationRepository(TDbContext context, ILogger<EmployeeRegistrationRepository<TDbContext>> logger) :
        base(
            context, logger)
    {
    }
}