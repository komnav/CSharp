using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.OrderDTOs;

public record OrderDto
{
    public Guid Id { get; init; }

    public Guid TableId { get; init; }

    public Guid FoodId { get; init; }

    public MenuItem MenuItem { get; init; }

    public DateTimeOffset DateTime { get; init; }

    public OrdersStatus Status { get; init; }
}