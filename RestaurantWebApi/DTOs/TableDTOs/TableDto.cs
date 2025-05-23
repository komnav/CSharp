using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.TableDTOs;

public record TableDto
{
    public Guid Id { get; init; }
    public int Number { get; init; }
    public int Capacity { get; init; }
    public TableType Type { get; init; }
}