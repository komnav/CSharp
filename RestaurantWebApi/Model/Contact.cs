namespace RestaurantWeb.Model;

public class Contact
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }

    public string LastName { get; set; }

    public string PassportSeries { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }
}