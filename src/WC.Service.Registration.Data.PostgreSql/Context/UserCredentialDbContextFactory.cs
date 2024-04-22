using Microsoft.Extensions.Configuration;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.Registration.Data.PostgreSql.Context;

public class UserCredentialDbContextFactory : PostgreSqlDbContextFactoryBase<UserCredentialDbContext>
{
    protected override string ConnectionString => "WorkChatDB";
    
    public UserCredentialDbContextFactory(IConfiguration configuration) : base(configuration)
    {
    }
}
