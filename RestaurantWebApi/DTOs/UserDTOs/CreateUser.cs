using RestaurantWeb.Model;

namespace RestaurantWeb.DTOs.UserDTOs;

public record CreateUser()
{
    public int Id { get; set; }

    public required string UserName { get; init; }

    public required string Password { get; init; }

    public required string Role { get; init; }

    public int? ContactId { get; init; }

    public Contact? Contact { get; init; }
}