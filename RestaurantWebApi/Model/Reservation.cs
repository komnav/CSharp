using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class Reservation
{
    public Guid Id { get; set; }

    public int TableId { get; set; }

    public Table Table { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public string Notes { get; set; }

    public ReservationStatus Status { get; set; }

    public Reservation()
    {
        Id = Guid.NewGuid();
    }
}