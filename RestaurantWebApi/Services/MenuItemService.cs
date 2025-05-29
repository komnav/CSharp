using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuItemDTOs;

namespace RestaurantWeb.Services;

public class MenuItemService : IMenuItemService
{
    public List<MenuItemDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public MenuItemDto GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public (ValidationResult validationResult, MenuItemDto dto) Create(CreateMenuItemDto menuItemDto)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdate(Guid id, UpdateMenuItemDto updateMenuItemDto)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto entity)
    {
        throw new NotImplementedException();
    }

    public bool TryDelete(Guid id)
    {
        throw new NotImplementedException();
    }
}