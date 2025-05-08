using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class MenuItem
{
    public int Id { get; set; }
    
    public int? CategoryId { get; set; }
    
    public MenuCategory? Category { get; set; }
    
    public decimal Price { get; set; }
    
    public required string Name { get; set; }
    
    public MenuItemStatus Status { get; set; }
}