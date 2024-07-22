using Autofac;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Service.Authentication.gRPC.Client;
using WC.Service.Employees.gRPC.Client;
using WC.Service.Registration.Domain.Services;

namespace WC.Service.Registration.Domain;

public class RegistrationDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<EmployeeClientModule>();
        builder.RegisterModule<AuthenticationClientModule>();

        builder.RegisterType<EmployeeRegistrationManager>()
            .As<IEmployeeRegistrationManager>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();

        builder.RegisterType<EmployeesClientConfiguration>()
            .As<IEmployeesClientConfiguration>()
            .InstancePerLifetimeScope();

        builder.RegisterType<AuthenticationClientConfiguration>()
            .As<IAuthenticationClientConfiguration>()
            .InstancePerLifetimeScope();

        builder.RegisterType<BCryptPasswordHasher>()
            .As<IBCryptPasswordHasher>()
            .InstancePerLifetimeScope();
    }
}
