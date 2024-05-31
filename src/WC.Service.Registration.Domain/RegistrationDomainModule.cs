using Autofac;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.PostgreSql;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.Domain;

public class RegistrationDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<RegistrationDataPostgreSqlModule>();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataProvider<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataManager<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();

        builder.RegisterType<BCryptPasswordHasher>().As<IBCryptPasswordHasher>().SingleInstance();
    }
}