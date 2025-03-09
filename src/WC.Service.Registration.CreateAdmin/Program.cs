﻿using Autofac;
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
            .Build();

        builder.RegisterInstance(configuration)
            .As<IConfiguration>()
            .SingleInstance();

        builder.RegisterModule<RegistrationDomainModule>();
        builder.RegisterType<CreateAdmin>();
        builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = new AdminSettingsOptions();
                configuration.GetSection("AdminSettings").Bind(options);
                return options;
            })
            .As<AdminSettingsOptions>()
            .SingleInstance();

        var container = builder.Build();

        await using var scope = container.BeginLifetimeScope();
        var createAdmin = scope.Resolve<CreateAdmin>();
        await createAdmin.Create();
    }
}
