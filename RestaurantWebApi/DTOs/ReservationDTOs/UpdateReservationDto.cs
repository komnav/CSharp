using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.ReservationDTOs;

public record UpdateReservationDto()
{
    public int TableId { get; init; }

    public DateTime From { get; init; }

    public DateTime To { get; init; }

    public string Notes { get; init; }

    public ReservationStatus Status { get; init; }
}