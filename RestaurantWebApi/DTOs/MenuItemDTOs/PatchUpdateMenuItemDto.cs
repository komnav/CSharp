using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.MenuItemDTOs;

public record PatchUpdateMenuItemDto
{
    public MenuItemStatus Status { get; init; }
}