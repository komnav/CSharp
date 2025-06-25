using Serilog;
using Serilog.Events;

namespace RestaurantWeb.Loggers;

public static class SerilogExtension
{
    public static void SendLog(this WebApplicationBuilder builder)
    {
        try
        {
            var logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Directory.CreateDirectory(logFolder);

            var botToken = "7650734335:AAFRR7Zd1P9KLKu4Kwni6gZkIwtjETpWoeo";
            var chatId = "6043341560";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.Sink(new TelegramSink(botToken, chatId), restrictedToMinimumLevel: LogEventLevel.Error)
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddLogging(logging =>
            {
                logging.AddFilter("Microsoft.AspNetCore.*", LogLevel.Warning);
                logging.AddFilter("System", LogLevel.Warning);
                logging.AddFilter("Default", LogLevel.Information);
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}