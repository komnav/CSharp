using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Losson9;

public class ExampleHostedService(ILogger<ExampleHostedService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation($"{DateTime.UtcNow}");
            await Task.Delay(2000, stoppingToken);
        }
    }
}