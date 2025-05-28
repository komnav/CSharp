namespace RestaurantWeb.Model;

public class MenuCategory
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public int? ParentId { get; set; }
}