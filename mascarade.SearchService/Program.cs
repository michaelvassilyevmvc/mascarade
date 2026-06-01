using System.Net;
using mascarade.SearchService.Consumers;
using mascarade.SearchService.Data;
using mascarade.SearchService.Services;
using MassTransit;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient<CostumeSvcHttpClient>()
    .AddPolicyHandler(GetPolicy());
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(x =>
{
    x.AddConsumersFromNamespaceContaining<CostumeCreatedConsumer>();
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("search", false));
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint("search-costume-created", e =>
        {
            e.UseMessageRetry(r => r.Interval(5, 5));
            e.ConfigureConsumer<CostumeCreatedConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();


app.UseAuthorization();
app.MapControllers();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    try
    {
        await DbInitializer.InitDb(app);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
});


app.Run();

static IAsyncPolicy<HttpResponseMessage> GetPolicy() => HttpPolicyExtensions
    .HandleTransientHttpError()
    .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
    .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));