using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.MenuItemDTOs;

public record CreateMenuItemDto
{
    public Guid? CategoryId { get; init; }

    public decimal Price { get; init; }

    public required string Name { get; init; }

    public MenuItemStatus Status { get; init; }
}