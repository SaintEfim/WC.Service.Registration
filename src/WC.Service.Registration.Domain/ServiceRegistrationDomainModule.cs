using Autofac;
using FluentValidation;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.PostgreSql;
using WC.Service.Registration.Domain.Helpers;

namespace WC.Service.Registration.Domain;

public class ServiceRegistrationDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<ServiceRegistrationDataPostgreSqlModule>();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataProvider<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataManager<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();

        builder.RegisterType<JwtHelper>().As<IJwtHelper>().SingleInstance();
        builder.RegisterType<HashHelper>().As<IHashHelper>().SingleInstance();
    }
}