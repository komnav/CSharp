using Serilog.Core;
using Serilog.Events;

namespace RestaurantWeb.Loggers;

public class TelegramSink : ILogEventSink
{
    private readonly string _botToken;
    private readonly string _chatId;
    private readonly HttpClient _httpClient = new();

    public TelegramSink(string botToken, string chatId)
    {
        _botToken = botToken;
        _chatId = chatId;
    }

    public void Emit(LogEvent logEvent)
    {
        if (logEvent.Level < LogEventLevel.Error) return;

        var message = logEvent.RenderMessage();

        try
        {
            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage" +
                      $"?chat_id={_chatId}&text={Uri.EscapeDataString("ERROR:\n" + message)}";
            _httpClient.GetAsync(url);
        }
        catch
        {
            //
        }
    }
}