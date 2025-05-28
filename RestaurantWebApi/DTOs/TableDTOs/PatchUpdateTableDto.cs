namespace RestaurantWeb.DTOs.TableDTOs;

public record PatchUpdateTableDto()
{
   public int Number { get; init; }
    
   public int Capacity { get; init; }
}