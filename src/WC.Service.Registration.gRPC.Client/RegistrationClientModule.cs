using Autofac;
using WC.Service.Registration.gRPC.GrpcClients;

namespace WC.Service.Registration.gRPC;

public class RegistrationClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<EmployeeClientManager>().As<IEmployeeClientManager>().SingleInstance();
        builder.RegisterType<EmployeeClientProvider>().As<IEmployeeClientProvider>().SingleInstance();
    }
}