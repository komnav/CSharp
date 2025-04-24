using RestaurantWebApi.Model.Enums;

namespace RestaurantWebApi.Model;

public class Order
{
    public int Id { get; set; }
    
    public int TableId { get; set; }
    
    public Table? Table { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public OrdersStatus Status { get; set; }
}