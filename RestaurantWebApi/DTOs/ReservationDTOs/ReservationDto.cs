using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.ReservationDTOs;

public record ReservationDto()
{
    public Guid Id { get; init; }
    
    public int TableId { get; init; }

    public Table Table { get; init; }
    
    public DateTimeOffset From { get; init; }
    
    public DateTimeOffset To { get; init; }
    
    public string Notes { get; init; }
    
    public ReservationStatus Status { get; init; }
}