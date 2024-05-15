using Microsoft.Extensions.Logging;
using WC.Service.Registration.Data.PostgreSql.Context;
using WC.Service.Registration.Data.Repository;

namespace WC.Service.Registration.Data.PostgreSql.Repository;

public class UserRegistrationRepository : UserRegistrationRepository<RegistrationDbContext>
{
    public UserRegistrationRepository(RegistrationDbContext context, ILogger<UserRegistrationRepository> logger) :
        base(
            context, logger)
    {
    }
}