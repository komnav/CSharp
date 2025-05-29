namespace RestaurantWeb.DTOs.MenuCategoryDTOs;

public record CreateMenuCategoryDto
{
    public required string Name { get; init; }

    public int? ParentId { get; init; }
}