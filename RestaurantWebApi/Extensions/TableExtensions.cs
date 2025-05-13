using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Model;

namespace RestaurantWeb.Extensions;

public static class TableExtensions
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