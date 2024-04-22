using Microsoft.Extensions.Logging;
using WC.Service.Registration.Data.PostgreSql.Context;
using WC.Service.Registration.Data.Repository;

namespace WC.Service.Registration.Data.PostgreSql.Repository;

public class UserCredentialRepository : UserCredentialRepository<UserCredentialDbContext>
{
    public UserCredentialRepository(UserCredentialDbContext context, ILogger<UserCredentialRepository> logger) : base(
        context, logger)
    {
    }
}