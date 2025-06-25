using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Extensions;

public static class ServerApiExtension
{
    public static void MapServerApIs(this WebApplication app)
    {
        app.MapGet("ServerInfo", ()
            =>
        {
            return Results.Ok(new { Info = "Bank management server", Version = "v1" });
        });
        app.MapPost(
            "TableWithMinApi", (
                TableDto tableDto,
                RestaurantContext restaurantContext,
                ILogger<Program> logger) =>
            {
                if (!Enum.IsDefined(typeof(TableType), tableDto.Type))
                {
                    logger.LogWarning("invalid {TableType}", tableDto.Type);
                    return Results.BadRequest();
                }

                var entry = restaurantContext.Tables.Add(new Table
                {
                    Type = tableDto.Type,
                    Number = tableDto.Number,
                    Capacity = tableDto.Capacity
                });
                restaurantContext.SaveChanges();

                DiagnosticsConfig.TableCounter.Add(
                    1,
                    new KeyValuePair<string, object>("table_type", tableDto.Type),
                    new KeyValuePair<string, object>("table.id", entry.Entity.Id)
                );

                return Results.Ok(entry.Entity.Id);
            });
    }
}