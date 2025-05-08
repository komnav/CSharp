using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Model;
using RestaurantWebApi.DTOs.TableDTOs;

namespace RestaurantWeb.Extensions;

public static class WorkerExtensions
{
    public static TableDto ToDto(this Table table)
    {
        return new TableDto
        {
            Id = table.Id,
            Number = table.Number,
            Capacity = table.Capacity,
            Type = table.Type
        };
    }
}