using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.TableDTOs;

public record CreateTableDto
{
    public int Number { get; init; }
    public int Capacity { get; init; }
    public TableType Type { get; init; }
}