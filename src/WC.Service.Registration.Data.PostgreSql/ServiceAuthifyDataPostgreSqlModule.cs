using Autofac;
using Microsoft.EntityFrameworkCore;
using WC.Library.Data.Repository;
using WC.Service.Registration.Data.PostgreSql.Context;

namespace WC.Service.Registration.Data.PostgreSql;

public class ServiceAuthifyDataPostgreSqlModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IRepository<>))
            .AsImplementedInterfaces();

        builder.RegisterType<UserCredentialDbContextFactory>()
            .AsSelf()
            .SingleInstance();
        
        builder.Register(c => c.Resolve<UserCredentialDbContextFactory>().CreateDbContext())
            .As<UserCredentialDbContext>()  
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}