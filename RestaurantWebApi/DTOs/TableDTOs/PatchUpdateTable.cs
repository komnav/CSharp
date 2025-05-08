namespace RestaurantWeb.DTOs.TableDTOs;

public record PatchUpdateTable()
{
    int Number { get; init; }
    int Capacity { get; init; }
}