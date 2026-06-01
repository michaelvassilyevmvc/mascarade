using mascarade.RentalService.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<RentalDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();
});
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(x =>
{
    x.AddEntityFrameworkOutbox<RentalDbContext>(o =>
    {
        o.QueryDelay = TimeSpan.FromSeconds(10);
        o.UsePostgres();
        o.UseBusOutbox();
    });
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("costume", false));
    x.UsingRabbitMq((context, cfg) => { cfg.ConfigureEndpoints(context); });
});

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();