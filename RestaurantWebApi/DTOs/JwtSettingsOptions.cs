namespace RestaurantWeb.DTOs;

public class JwtSettingsOptions
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public TimeSpan TokenLifetime { get; set; }
}