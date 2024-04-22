using Microsoft.Extensions.Configuration;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.Registration.Data.PostgreSql.Context;

public class UserRegistrationDbContextFactory : PostgreSqlDbContextFactoryBase<UserRegistrationDbContext>
{
    protected override string ConnectionString => "WorkChatDB";

    public UserRegistrationDbContextFactory(IConfiguration configuration) : base(configuration)
    {
    }
}