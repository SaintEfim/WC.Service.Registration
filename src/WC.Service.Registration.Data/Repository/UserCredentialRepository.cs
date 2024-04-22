using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Repository;
using WC.Service.Registration.Data.Models;

namespace WC.Service.Registration.Data.Repository;

public class UserCredentialRepository<TDbContext> :
    RepositoryBase<UserCredentialRepository<TDbContext>, TDbContext, UserCredentialEntity>,
    IUserCredentialRepository
    where TDbContext : DbContext
{
    protected UserCredentialRepository(TDbContext context, ILogger<UserCredentialRepository<TDbContext>> logger) : base(
        context, logger)
    {
    }
}