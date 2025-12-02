using RestWithASPNET10Erudio.Configurations;
using RestWithASPNET10Erudio.Repositories;
using RestWithASPNET10Erudio.Repositories.Implementations;
using RestWithASPNET10Erudio.Services;
using RestWithASPNET10Erudio.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddDataBaseConfiguration(builder.Configuration);
builder.Services.AddSingleton<MathService>();
builder.Services.AddScoped<IPersonsServices, PersonsServicesImplementations>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
