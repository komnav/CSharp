using RestaurantWeb.DTOs.MenuCategoryDTOs;
using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuItemDTOs;

namespace RestaurantWeb.Services;

public interface IMenuCategoryService
{
    Task<List<MenuCategoryDto>> GetAll();

    Task<MenuCategoryDto> GetById(Guid id);

    Task<MenuCategoryDto> Create(CreateMenuCategoryDto createMenuCategory);

    Task<bool> TryUpdate(Guid id, UpdateMenuCategoryDto updateMenuCategory);

    Task<bool> TryUpdateSpecificProperties(Guid id, PatchMenuCategoryDto entity);

    Task<bool> TryDelete(Guid id);
}