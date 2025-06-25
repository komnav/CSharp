namespace RestaurantWeb.Extensions;

public static class GeneralExtensions
{
    public static void AddExtensions(this WebApplicationBuilder builder)
    {
        builder.AddOpenTelemetryExtension();
        
        builder.AddInterceptorsLayer();
        
        builder.AddDbContextLayer();
        
        builder.AddRepositoryLayer();
        
        builder.AddServiceLayer();
        
        builder.AddRedisServiceLayer();
        
        builder.AddAutoMapperLayer();
    }
}