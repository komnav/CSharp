namespace RestaurantWeb.DTOs.MenuCategoryDTOs;

public record MenuCategoryDto
{
    public Guid Id { get; init; }

    public required string Name { get; init; }

    public int? ParentId { get; init; }
}