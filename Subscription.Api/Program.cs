using Scalar.AspNetCore;
using Serilog;
using Serilog.Events;
using Subscription.Api.Extensions;
using Subscription.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddRouting(map => map.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer(); //Swagger
builder.Services.AddSwaggerGen(); //Swagger

builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddDomainServices();

//Configurar o Serilog
Log.Logger = new LoggerConfiguration().MinimumLevel
    .Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq(builder.Configuration["Seq:Url"] ?? string.Empty)
    .CreateLogger();

//Habilitando o Serilog
builder.Host.UseSerilog();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapScalarApiReference(option =>
{
    option.WithTheme(ScalarTheme.BluePlanet);
});

app.MapOpenApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
