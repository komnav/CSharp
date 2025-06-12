using RestaurantWeb.DTOs.MenuCategoryDTOs;
using RestaurantWeb.Exceptions;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class MenuCategoryService(IMenuCategoryRepository repository) : IMenuCategoryService
{
    private readonly IMenuCategoryRepository _repository;

    public async Task<List<MenuCategoryDto>> GetAll()
    {
        var reservations = await _repository.GetAll();
        return reservations.Select(s => new MenuCategoryDto()
        {
            Id = s.Id,
            Name = s.Name,
            ParentId = s.ParentId
        }).ToList();
    }

    public async Task<MenuCategoryDto> GetById(Guid id)
    {
        var menuItem = await _repository.GetById(id);
        return new MenuCategoryDto()
        {
            Id = menuItem.Id,
            Name = menuItem.Name,
            ParentId = menuItem.ParentId
        };
    }

    public async Task<MenuCategoryDto> Create(CreateMenuCategoryDto menuCategory)
    {
        var createMenuItem = new MenuCategory()
        {
            Name = menuCategory.Name,
            ParentId = menuCategory.ParentId
        };
        var create = await _repository.Create(createMenuItem);
        if (create < 0)
            throw new ResourceWasNotCreatedException(nameof(createMenuItem));

        return new MenuCategoryDto()
        {
            Id = createMenuItem.Id,
            Name = createMenuItem.Name,
            ParentId = createMenuItem.ParentId
        };
    }

    public async Task<bool> TryUpdate(Guid id, UpdateMenuCategoryDto updateMenuCategory)
    {
        var update = await _repository.TryUpdate(
            id,
            updateMenuCategory.Name,
            updateMenuCategory.ParentId);
        if (!update)
            throw new ResourceWasNotUpdatedException(nameof(update));

        return true;
    }

    public async Task<bool> TryUpdateSpecificProperties(Guid id, PatchMenuCategoryDto entity)
    {
        var serverSide = await _repository.GetById(id);
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSide.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSide, value);
            }
        }

        var update = await _repository.TryUpdate(
            id,
            serverSide.Name,
            serverSide.ParentId);
        if (!update)
            throw new ResourceWasNotUpdatedException(nameof(entity));

        return true;
    }

    public async Task<bool> TryDelete(Guid id)
    {
        var delete = await _repository.Delete(id);
        if (delete < 0)
            return false;
        return true;
    }
}