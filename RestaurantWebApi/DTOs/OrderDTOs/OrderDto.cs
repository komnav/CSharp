using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.OrderDTOs;

public record OrderDto
{
    public Guid Id { get; init; }

    public int TableId { get; init; }

    public int FoodId { get; init; }

    public MenuItem MenuItem { get; init; }

    public DateTime DateTime { get; init; }

    public OrdersStatus Status { get; init; }
}