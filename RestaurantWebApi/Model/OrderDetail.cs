using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class OrderDetail
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Order Order { get; set; }

    public Guid MenuItemId { get; set; }

    public MenuItem MenuItem { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public OrderDetailStatus Status { get; set; }
}