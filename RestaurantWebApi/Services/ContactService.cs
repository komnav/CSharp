using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.ContactDTOs;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class ContactService(
    IContactRepository repository,
    IMapper mapper,
    IServiceProvider serviceProvider) : IContactService
{
    public List<ContactDto> GetAll()
    {
        var getAll = repository.GetAll();
        var map = mapper.Map<List<ContactDto>>(getAll);
        return map;
    }

    public ContactDto GetById(Guid id)
    {
        var getById = repository.GetById(id);
        var map = mapper.Map<ContactDto>(getById);
        return map;
    }

    public (ValidationResult validationResult, ContactDto dto) Create(CreateContactDto contactDto)
    {
        var validator = serviceProvider.GetService<IValidator<CreateContactDto>>();
        if (validator != null)
        {
            var result = validator.Validate(contactDto);
            if (!result.IsValid)
            {
                return (result, null);
            }
        }

        var newContact = new Contact
        {
            FirstName = contactDto.FirstName,
            LastName = contactDto.LastName,
            Email = contactDto.Email,
            PassportSeries = contactDto.PassportSeries,
            PhoneNumber = contactDto.PhoneNumber,
            Address = contactDto.Address
        };
        repository.Create(newContact);

        var map = mapper.Map<ContactDto>(newContact);
        return (null, map);
    }

    public bool TryUpdate(Guid id, UpdateContactDto updateContactDto)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateContactDto entity)
    {
        var serverSideContact = repository.GetById(id);
        var serverContact = serverSideContact.GetType();
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSideContact.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSideContact, value);
            }
        }

        repository.TryUpdate(id, serverSideContact);
        mapper.Map(serverSideContact, entity);
        return true;
    }

    public bool TryDelete(Guid id)
    {
        var delete = repository.Delete(id);
        return delete is not null;
    }
}