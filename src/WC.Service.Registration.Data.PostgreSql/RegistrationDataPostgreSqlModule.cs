using Autofac;
using Microsoft.EntityFrameworkCore;
using WC.Library.Data.Repository;
using WC.Service.Registration.Data.PostgreSql.Context;

namespace WC.Service.Registration.Data.PostgreSql;

public class RegistrationDataPostgreSqlModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IRepository<>))
            .AsImplementedInterfaces();

        builder.RegisterType<RegistrationDbContextFactory>()
            .AsSelf()
            .SingleInstance();

        builder.Register(c => c.Resolve<RegistrationDbContextFactory>().CreateDbContext())
            .As<RegistrationDbContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}