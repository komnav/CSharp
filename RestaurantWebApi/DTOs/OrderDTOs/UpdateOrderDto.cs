using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.OrderDTOs;

public class UpdateOrderDto
{
    public int TableId { get; init; }
    
    public int FoodId { get; init; }
    
    public MenuItem MenuItem { get; init; }
    
    public DateTimeOffset DateTime { get; init; }

    public OrdersStatus Status { get; init; }
}