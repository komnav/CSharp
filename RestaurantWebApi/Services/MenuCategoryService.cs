using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuCategoryDTOs;
using RestaurantWeb.DTOs.MenuItemDTOs;

namespace RestaurantWeb.Services;

public class MenuCategoryService : IMenuCategoryService
{
    public List<MenuCategoryDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public MenuCategoryDto GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public (ValidationResult validationResult, MenuCategoryDto dto) Create(CreateMenuCategoryDto createMenuCategory)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdate(Guid id, UpdateMenuCategoryDto updateMenuCategory)
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