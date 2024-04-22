using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Repository;
using WC.Service.Registration.Data.Models;

namespace WC.Service.Registration.Data.Repository;

public class UserRegistrationRepository<TDbContext> :
    RepositoryBase<UserRegistrationRepository<TDbContext>, TDbContext, UserRegistrationEntity>,
    IUserRegistrationRepository
    where TDbContext : DbContext
{
    protected UserRegistrationRepository(TDbContext context, ILogger<UserRegistrationRepository<TDbContext>> logger) :
        base(
            context, logger)
    {
    }
}