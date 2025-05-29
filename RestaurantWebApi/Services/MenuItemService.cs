using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuItemDTOs;
using RestaurantWeb.Model;
using RestaurantWeb.Repositories;

namespace RestaurantWeb.Services;

public class MenuItemService(
    IMenuItemRepository repository,
    IMapper mapper,
    IServiceProvider serviceProvider) : IMenuItemService
{
    public List<MenuItemDto> GetAll()
    {
        var getAll = repository.GetAll();
        var map = mapper.Map<List<MenuItemDto>>(getAll);
        return map;
    }

    public MenuItemDto GetById(Guid id)
    {
        var get = repository.GetById(id);
        var map = mapper.Map<MenuItemDto>(get);
        return map;
    }

    public (ValidationResult validationResult, MenuItemDto dto) Create(CreateMenuItemDto menuItemDto)
    {
        var validator = serviceProvider.GetService<IValidator<CreateMenuItemDto>>();
        if (validator != null)
        {
            var result = validator.Validate(menuItemDto);
            if (!result.IsValid)
            {
                return (result, null);
            }
        }

        var newMenuItem = new MenuItem
        {
            CategoryId = menuItemDto.CategoryId,
            Name = menuItemDto.Name,
            Price = menuItemDto.Price,
            Status = menuItemDto.Status
        };
        repository.Create(newMenuItem);

        var map = mapper.Map<MenuItemDto>(newMenuItem);
        return (null, map);
    }

    public bool TryUpdate(Guid id, UpdateMenuItemDto updateMenuItemDto)
    {
        var get = repository.GetById(id);
        var map = mapper.Map(updateMenuItemDto, get);
        repository.TryUpdate(id, map);
        return true;
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto entity)
    {
        var serverSideMenuItem = repository.GetById(id);
        var serverReservation = serverSideMenuItem.GetType();
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSideMenuItem.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSideMenuItem, value);
            }
        }

        repository.TryUpdate(id, serverSideMenuItem);
        mapper.Map(serverSideMenuItem, entity);
        return true;
    }

    public bool TryDelete(Guid id)
    {
        var delete = repository.Delete(id);
        return delete is not null;
    }
}