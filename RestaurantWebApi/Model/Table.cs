using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class Table : IEntity
{
    public int Number { get; set; }
    public int Capacity { get; set; }
    public TableType Type { get; set; }
    public Guid Id { get; set; }
}