namespace RestaurantWeb.DTOs.ContactDTOs;

public record ContactDto
{
    public Guid Id { get; init; }

    public required string FirstName { get; init; }

    public string LastName { get; init; }

    public string PassportSeries { get; init; }

    public string Email { get; init; }

    public string PhoneNumber { get; init; }

    public string Address { get; init; }
}