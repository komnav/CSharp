using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuItemDTOs;

namespace RestaurantWeb.Services;

public interface IMenuItemService
{
    List<MenuItemDto> GetAll();

    MenuItemDto GetById(Guid id);

    (ValidationResult validationResult, MenuItemDto dto) Create(CreateMenuItemDto menuItemDto);

    bool TryUpdate(Guid id, UpdateMenuItemDto updateMenuItemDto);

    bool TryUpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto entity);

    bool TryDelete(Guid id);
}