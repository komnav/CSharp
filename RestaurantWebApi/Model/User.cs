namespace RestaurantWeb.Model;

public class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public int? ContactId { get; set; }

    public Contact Contact { get; set; }
}