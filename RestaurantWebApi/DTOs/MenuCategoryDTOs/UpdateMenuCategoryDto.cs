namespace RestaurantWeb.DTOs.MenuCategoryDTOs;

public record UpdateMenuCategoryDto
{
    public required string Name { get; init; }

    public int? ParentId { get; init; }
}