namespace RestaurantWebApi.Model;

public class MenuCategory
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public int? ParentId { get; set; }
}