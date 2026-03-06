using Scalar.AspNetCore;
using Subscription.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddRouting(map => map.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer(); //Swagger
builder.Services.AddSwaggerGen(); //Swagger

builder.Services.AddInfraStructure(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapScalarApiReference(option =>
{
    option.WithTheme(ScalarTheme.BluePlanet);
});

app.MapOpenApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
