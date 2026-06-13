using UnitConversion.Api.Services;
using UnitConversion.API.Providers;
using UnitConversion.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IUnitDefinitionProvider, InMemoryUnitDefinitionProvider>();
builder.Services.AddScoped<IConversionService, ConversionService>();
 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
// ── App pipeline ──────────────────────────────────────────────────────────────
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
