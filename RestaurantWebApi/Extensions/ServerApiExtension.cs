namespace RestaurantWeb.Extensions;

public static class ServerApiExtension
{
    public static void MapServerAPIs(this WebApplication app)
    {
        app.MapGet("Serverinfo", ()
            =>
        {
            return Results.Ok(new { Info = "Bank management server", Version = "v1" });
        });
        app.MapPost("Message", (string message)
            =>
        {
            return Results.Ok(message = "Hi");
        });
    }
}