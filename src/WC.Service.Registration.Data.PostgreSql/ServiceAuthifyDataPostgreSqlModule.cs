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

        builder.RegisterType<UserRegistrationDbContextFactory>()
            .AsSelf()
            .SingleInstance();

        builder.Register(c => c.Resolve<UserRegistrationDbContextFactory>().CreateDbContext())
            .As<UserRegistrationDbContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}