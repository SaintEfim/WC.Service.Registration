using Autofac;
using WC.Service.Registration.gRPC.GrpcClients;

namespace WC.Service.Registration.gRPC;

public class RegistrationClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<EmployeeRegistrationClientManager>().As<IEmployeeRegistrationClientManager>().SingleInstance();
        builder.RegisterType<EmployeeRegistrationClientProvider>().As<IEmployeeRegistrationClientProvider>().SingleInstance();
    }
}