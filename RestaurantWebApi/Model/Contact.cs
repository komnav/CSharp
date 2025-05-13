namespace RestaurantWeb.Model;

public class Contact : IEntity
{
    public required string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PassportSeries { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }
    public Guid Id { get; set; }
}