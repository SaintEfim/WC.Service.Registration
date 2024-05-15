using Microsoft.Extensions.Configuration;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.Registration.Data.PostgreSql.Context;

public class RegistrationDbContextFactory : PostgreSqlDbContextFactoryBase<RegistrationDbContext>
{
    protected override string ConnectionString => "WorkChatDB";

    public RegistrationDbContextFactory(IConfiguration configuration) : base(configuration)
    {
    }
}