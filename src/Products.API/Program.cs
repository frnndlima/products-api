using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Products.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDocumentation();
builder.AddDataContexts();
builder.AddMediatr();
builder.AddCarter();
builder.AddValidators();
builder.AddExceptionHandler();
builder.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.ConfigureDevEnvironment();
app.ConfigureCarter();
app.ConfigureExceptionHandler();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.Run();
