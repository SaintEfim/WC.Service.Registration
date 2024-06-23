using Autofac;
using WC.Service.Registration.gRPC.Client.Clients.Employees;
using WC.Service.Registration.gRPC.Client.Clients.Positions;
using WC.Service.Registration.gRPC.Clients.Employees;
using WC.Service.Registration.gRPC.Clients.Positions;

namespace WC.Service.Registration.gRPC;

public class RegistrationClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<GreeterEmployeesClient>().As<IGreeterEmployeesClient>().InstancePerLifetimeScope();
        builder.RegisterType<GreeterPositionsClient>().As<IGreeterPositionsClient>().InstancePerLifetimeScope();
    }
}