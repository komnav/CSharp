using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Model;

public class Table
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public int Capacity { get; set; }

    public TableType Type { get; set; }
}