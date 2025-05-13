using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class Reservation: IEntity
{
    public int TableId { get; set; }

    public Table? Table { get; set; }
    
    public DateTime From { get; set; }
    
    public DateTime To { get; set; }
    
    public string? Notes { get; set; }
    
    public ReservationStatus Status { get; set; }
    public Guid Id { get; set; }
}