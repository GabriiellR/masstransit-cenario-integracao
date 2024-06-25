using Intranet.Consumers;
using Intranet.ModulesIoc;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CentroCustoConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        cfg.ReceiveEndpoint("atualizar-centro-custo", e =>
        {
            e.UseMessageRetry(r => r.Interval(2, 100));
            e.ConfigureConsumer<CentroCustoConsumer>(context);
        });
    });
});

builder.Services.AddHostedService<MassTransitHostedService>();

Modules.RegisterModules(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
