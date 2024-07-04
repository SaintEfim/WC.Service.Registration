using Autofac;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Service.Registration.Domain.Services;

namespace WC.Service.Registration.Domain;

public class RegistrationDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<EmployeeRegistrationManager>()
            .AsImplementedInterfaces()
            .SingleInstance();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();

        builder.RegisterType<EmployeesesClientConfiguration>()
            .As<IEmployeesClientConfiguration>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<BCryptPasswordHasher>()
            .As<IBCryptPasswordHasher>()
            .InstancePerLifetimeScope();
    }
}