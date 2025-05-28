using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISendGridClient>(new SendGridClient(Environment.GetEnvironmentVariable("SendGridApiKey")));

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
