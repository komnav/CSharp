using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuItemDTOs;

namespace RestaurantWeb.Services;

public interface IMenuItemService
{
    Task<List<MenuItemDto>> GetAll();

    Task<MenuItemDto> GetById(Guid id);

    Task<MenuItemDto> Create(CreateMenuItemDto menuItemDto);

    Task<bool> TryUpdate(Guid id, UpdateMenuItemDto updateMenuItemDto);

    Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto entity);

    Task<bool> TryDelete(Guid id);
}