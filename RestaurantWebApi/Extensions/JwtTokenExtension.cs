using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RestaurantWeb.DTOs;

namespace RestaurantWeb.Extensions;

public static class JwtTokenExtension
{
    public static void JwtAuthServiceExtensions(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;

        builder.Services.Configure<JwtSettingsOptions>(
            builder.Configuration.GetSection("Jwt"));

        var jwtSettings = config.GetSection("Jwt").Get<JwtSettingsOptions>();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings!.Key)),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuer = true,
                ValidateAudience = true
            };
        });
    }
}