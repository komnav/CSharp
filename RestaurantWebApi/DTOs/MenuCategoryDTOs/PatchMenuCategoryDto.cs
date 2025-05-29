namespace RestaurantWeb.DTOs.MenuCategoryDTOs;

public record PatchMenuCategoryDto
{
    public int? ParentId { get; init; }
}