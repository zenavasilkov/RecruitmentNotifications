using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RecruitmentNotifications.Options;
using RecruitmentNotifications.Servises;

namespace RecruitmentNotifications.Extensions;

public static class ServiceExtensionCollections
{
    public static IServiceCollection AddNotifications(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.SectionName));

        services.AddScoped<IMessageSender, MessageSender>();

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.UsingRabbitMq((context, rabbitMqConfigurator) =>
            {
                var rabbitMqOptions = context.GetRequiredService<IOptions<RabbitMqOptions>>().Value;

                rabbitMqConfigurator.Host(rabbitMqOptions.HostName, rabbitMqOptions.VirtualHostName, configure =>
                {
                    configure.Username(rabbitMqOptions.UserName);
                    configure.Password(rabbitMqOptions.Password);
                });

                rabbitMqConfigurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
