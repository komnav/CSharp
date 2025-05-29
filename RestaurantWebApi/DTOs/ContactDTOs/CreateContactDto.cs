namespace RestaurantWeb.DTOs.ContactDTOs;

public record CreateContactDto
{
    public required string FirstName { get; init; }

    public string LastName { get; init; }

    public string PassportSeries { get; init; }

    public string Email { get; init; }

    public string PhoneNumber { get; init; }

    public string Address { get; init; }
}