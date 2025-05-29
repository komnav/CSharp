namespace RestaurantWeb.DTOs.ContactDTOs;

public record PatchUpdateContactDto
{
    public string PhoneNumber { get; init; }

    public string Address { get; init; }
}