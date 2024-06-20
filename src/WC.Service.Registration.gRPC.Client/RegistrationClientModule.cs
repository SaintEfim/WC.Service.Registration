using Autofac;
using WC.Service.Registration.gRPC.Client.GrpcClients;
using WC.Service.Registration.gRPC.GrpcClients;
using WC.Service.Registration.gRPC.GrpcClients.Employee;

namespace WC.Service.Registration.gRPC;

public class RegistrationClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<EmployeeClient>().As<IEmployeeClient>().InstancePerLifetimeScope();
    }
}