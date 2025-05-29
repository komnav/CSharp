using RestaurantWeb.DTOs.ContactDTOs;
using FluentValidation.Results;

namespace RestaurantWeb.Services;

public interface IContactService
{
    List<ContactDto> GetAll();

    ContactDto GetById(Guid id);

    (ValidationResult validationResult, ContactDto dto) Create(CreateContactDto contactDto);

    bool TryUpdate(Guid id, UpdateContactDto updateContactDto);

    bool TryUpdateSpecificProperties(Guid id, PatchUpdateContactDto entity);

    bool TryDelete(Guid id);
}