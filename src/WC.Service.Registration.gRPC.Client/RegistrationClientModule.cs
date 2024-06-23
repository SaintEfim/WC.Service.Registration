using Autofac;
using WC.Service.Registration.gRPC.Client.Clients;

namespace WC.Service.Registration.gRPC.Client;

public class RegistrationClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<GreeterEmployeesClient>().As<IGreeterEmployeesClient>().InstancePerLifetimeScope();
        builder.RegisterType<GreeterPositionsClient>().As<IGreeterPositionsClient>().InstancePerLifetimeScope();
    }
}