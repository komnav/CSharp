using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class Order: IEntity
{
    public int TableId { get; set; }
    
    public Table Table { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public OrdersStatus Status { get; set; }
    public Guid Id { get; set; }
}