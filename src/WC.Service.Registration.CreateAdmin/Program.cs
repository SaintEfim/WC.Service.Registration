using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WC.Service.Registration.Domain;

namespace WC.Service.Registration.CreateAdmin;

internal static class Program
{
    private static async Task Main()
    {
        var builder = new ContainerBuilder();

        builder.RegisterInstance(LoggerFactory.Create(loggingBuilder => { loggingBuilder.AddConsole(); }))
            .As<ILoggerFactory>()
            .SingleInstance();

        builder.RegisterGeneric(typeof(Logger<>))
            .As(typeof(ILogger<>))
            .SingleInstance();

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var projectPath = Path.Combine(basePath, "..", "..", "..");

        var configuration = new ConfigurationBuilder().SetBasePath(projectPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        builder.RegisterInstance(configuration)
            .As<IConfiguration>()
            .SingleInstance();

        builder.RegisterModule<RegistrationDomainModule>();
        builder.RegisterType<CreateAdmin>();
        builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var adminSection = configuration.GetSection("AdminSettings");

                var adminEmailLocalPart = adminSection.GetValue<string>("AdminEmailLocalPart");
                var adminEmailDomain = adminSection.GetValue<string>("AdminEmailDomain");
                var adminRegistrationName = adminSection.GetValue<string>("AdminRegistrationName");
                var adminRegistrationSurname = adminSection.GetValue<string>("AdminRegistrationSurname");
                var adminRegistrationPatronymic = adminSection.GetValue<string>("AdminRegistrationPatronymic");
                var adminRegistrationPassword = adminSection.GetValue<string>("AdminRegistrationPassword");
                var adminPositionId = adminSection.GetValue<string>("AdminPositionId");

                return new AdminSettingsOptions
                {
                    AdminEmailLocalPart = adminEmailLocalPart,
                    AdminEmailDomain = adminEmailDomain,
                    AdminRegistrationName = adminRegistrationName,
                    AdminRegistrationSurname = adminRegistrationSurname,
                    AdminRegistrationPatronymic = adminRegistrationPatronymic,
                    AdminRegistrationPassword = adminRegistrationPassword,
                    AdminPositionId = Guid.Parse(adminPositionId!)
                };
            })
            .As<AdminSettingsOptions>()
            .SingleInstance();

        var container = builder.Build();

        await using var scope = container.BeginLifetimeScope();
        var createAdmin = scope.Resolve<CreateAdmin>();
        await createAdmin.Create();
    }
}
