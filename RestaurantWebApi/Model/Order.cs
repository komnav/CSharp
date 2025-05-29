using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class Order
{
    public Guid Id { get; set; }

    public int TableId { get; set; }

    public Table Table { get; set; }

    public int FoodId { get; set; }

    public MenuItem MenuItem { get; set; }

    public DateTime DateTime { get; set; }

    public OrdersStatus Status { get; set; }

    public Order()
    {
        Id = Guid.NewGuid();
    }
}