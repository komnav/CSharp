using System.Diagnostics;
using System.Diagnostics.Metrics;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace RestaurantWeb.Extensions;

public static class OpenTelemetryExtension
{
    public static void AddOpenTelemetryExtension(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(DiagnosticsConfig.ServiceName))
            .WithMetrics(metrics =>
            {
                metrics
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();

                metrics.AddMeter(DiagnosticsConfig.Meter.Name);

                metrics.AddOtlpExporter();
            })
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation();

                tracing.AddOtlpExporter();
            });
        builder.Logging.AddOpenTelemetry(logging => logging.AddOtlpExporter());
    }
}

public static class DiagnosticsConfig
{
    public const string ServiceName = "RestaurantWeb";

    public static Meter Meter = new(ServiceName);

    public static Counter<int> TableCounter = Meter.CreateCounter<int>("table.count");
}