using RestaurantWeb.DTOs.MenuCategoryDTOs;
using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuItemDTOs;

namespace RestaurantWeb.Services;

public interface IMenuCategoryService
{
    List<MenuCategoryDto> GetAll();

    MenuCategoryDto GetById(Guid id);

    (ValidationResult validationResult, MenuCategoryDto dto) Create(CreateMenuCategoryDto createMenuCategory);

    bool TryUpdate(Guid id, UpdateMenuCategoryDto updateMenuCategory);

    bool TryUpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto entity);

    bool TryDelete(Guid id);
}