using Intranet.Consumers;
using Intranet.ModulesIoc;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<DeleteCentroCustoConsumer>();
    x.AddConsumer<CreateCentroCustoConsumer>();
    x.AddConsumer<UpdateCentroCustoConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        cfg.ReceiveEndpoint("Delete", e =>
        {
            e.UseMessageRetry(r => r.Interval(2, 100));
            e.ConfigureConsumer<DeleteCentroCustoConsumer>(context);
            e.UseJsonSerializer();
        });
        
        cfg.ReceiveEndpoint("Create", e =>
        {
            e.UseMessageRetry(r => r.Interval(2, 100));
            e.ConfigureConsumer<CreateCentroCustoConsumer>(context);
            e.UseJsonSerializer();
        });
        
        cfg.ReceiveEndpoint("Update", e =>
        {
            e.UseMessageRetry(r => r.Interval(2, 100));
            e.ConfigureConsumer<UpdateCentroCustoConsumer>(context);
            e.UseJsonSerializer();
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
