using RestWithASPNET10Erudio.Services;
using RestWithASPNET10Erudio.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<MathService>();
builder.Services.AddScoped<IPersonsServices, PersonsServicesImplementations>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
