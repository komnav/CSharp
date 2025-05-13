namespace RestaurantWeb.DTOs.TableDTOs;

public record PatchUpdateTableDto()
{
    int Number { get; init; }
    
    int Capacity { get; init; }
}