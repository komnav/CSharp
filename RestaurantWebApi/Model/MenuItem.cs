using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class MenuItem : IEntity
{
    public int? CategoryId { get; set; }

    public MenuCategory? Category { get; set; }

    public decimal Price { get; set; }

    public required string Name { get; set; }

    public MenuItemStatus Status { get; set; }
    public Guid Id { get; set; }
}