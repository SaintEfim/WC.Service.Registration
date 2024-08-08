using Autofac;
using FluentValidation;
using WC.Service.Authentication.gRPC.Client;
using WC.Service.EmailDomains.gRPC.Client;
using WC.Service.Employees.gRPC.Client;
using WC.Service.Registration.Domain.Services;

namespace WC.Service.Registration.Domain;

public class RegistrationDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<EmployeesClientModule>();
        builder.RegisterModule<EmailDomainsClientModule>();
        builder.RegisterModule<AuthenticationClientModule>();

        builder.RegisterType<EmployeesClientConfiguration>()
            .As<IEmployeesClientConfiguration>()
            .InstancePerLifetimeScope();

        builder.RegisterType<AuthenticationClientConfiguration>()
            .As<IAuthenticationClientConfiguration>()
            .InstancePerLifetimeScope();

        builder.RegisterType<RegistrationManager>()
            .As<IRegistrationManager>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();
    }
}
