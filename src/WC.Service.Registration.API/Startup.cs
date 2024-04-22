using Autofac;
using FluentValidation;
using WC.Service.Registration.Domain;
using StartupBase = WC.Library.Web.Startup.StartupBase;

namespace WC.Service.Registration.API;

public class Startup : StartupBase
{
    public Startup(WebApplicationBuilder builder) : base(builder)
    {
    }

    public override void ConfigureContainer(
        ContainerBuilder builder)
    {
        base.ConfigureContainer(builder);
        builder.RegisterModule<ServiceAuthifyDomainModule>();
        
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();
    }
}