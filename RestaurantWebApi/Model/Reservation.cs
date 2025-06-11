using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class Reservation
{
    public Guid Id { get; set; }

    public Guid TableId { get; set; }

    public Table Table { get; set; }

    public DateTimeOffset From { get; set; }

    public DateTimeOffset To { get; set; }

    public string Notes { get; set; }

    public ReservationStatus Status { get; set; }

    public Reservation()
    {
        Id = Guid.NewGuid();
    }
}