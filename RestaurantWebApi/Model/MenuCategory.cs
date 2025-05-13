namespace RestaurantWeb.Model;

public class MenuCategory: IEntity
{
    public required string Name { get; set; }
    
    public int? ParentId { get; set; }
    public Guid Id { get; set; }
}