using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.ReservationDTOs;

public record UpdateReservationDto()
{
    public Guid TableId { get; init; }

    public Guid CustomerId { get; set; }

    public DateTimeOffset From { get; init; }

    public DateTimeOffset To { get; init; }

    public string Notes { get; init; }

    public ReservationStatus Status { get; init; }
}