using Autofac;
using WC.Service.Registration.gRPC.Services;

namespace WC.Service.Registration.gRPC;

public class RegistrationClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<EmployeeServiceClient>().As<IEmployeeRegistrationClient>().SingleInstance();
    }
}