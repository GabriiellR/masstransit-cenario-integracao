using Benner.ModulesIoc;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = new ServiceCollection();

serviceProvider.AddMassTransit(x =>
{
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
    {
        config.Host("amqp://guest:guest@localhost:5672");
    }));
});

serviceProvider.AddHostedService<MassTransitHostedService>();


Modules.RegisterModules(serviceProvider);