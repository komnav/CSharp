using FluentValidation.Results;
using RestaurantWeb.DTOs.ContactDTOs;

namespace RestaurantWeb.Services;

public class ContactService : IContactService
{
    public List<ContactDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public ContactDto GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public (ValidationResult validationResult, ContactDto dto) Create(CreateContactDto contactDto)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdate(Guid id, UpdateContactDto updateContactDto)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateContactDto entity)
    {
        throw new NotImplementedException();
    }

    public bool TryDelete(Guid id)
    {
        throw new NotImplementedException();
    }
}