using Autofac;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Service.Employees.gRPC.Client;
using WC.Service.Registration.Domain.Services;

namespace WC.Service.Registration.Domain;

public class RegistrationDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<EmployeeClientModule>();

        builder.RegisterType<EmployeeRegistrationManager>()
            .As<IEmployeeRegistrationManager>()
            .SingleInstance();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();

        builder.RegisterType<EmployeesClientConfiguration>()
            .As<IEmployeesClientConfiguration>()
            .InstancePerLifetimeScope();

        builder.RegisterType<BCryptPasswordHasher>()
            .As<IBCryptPasswordHasher>()
            .InstancePerLifetimeScope();
    }
}