using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuCategoryDTOs;
using RestaurantWeb.DTOs.MenuItemDTOs;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class MenuCategoryService(
    IMenuCategoryRepository repository,
    IMapper mapper,
    IServiceProvider serviceProvider) : IMenuCategoryService
{
    public List<MenuCategoryDto> GetAll()
    {
        var getAll = repository.GetAll();
        var map = mapper.Map<List<MenuCategoryDto>>(getAll);
        return map;
    }

    public MenuCategoryDto GetById(Guid id)
    {
        var getOrder = repository.GetById(id);
        var map = mapper.Map<MenuCategoryDto>(getOrder);
        return map;
    }

    public (ValidationResult validationResult, MenuCategoryDto dto) Create(CreateMenuCategoryDto createMenuCategory)
    {
        var validator = serviceProvider.GetService<IValidator<CreateMenuCategoryDto>>();
        if (validator != null)
        {
            var result = validator.Validate(createMenuCategory);
            if (!result.IsValid)
            {
                return (result, null);
            }
        }

        var newMenuCategory = new MenuCategory
        {
            Name = createMenuCategory.Name,
            ParentId = createMenuCategory.ParentId
        };
        repository.Create(newMenuCategory);

        var map = mapper.Map<MenuCategoryDto>(newMenuCategory);
        return (null, map);
    }

    public bool TryUpdate(Guid id, UpdateMenuCategoryDto updateMenuCategory)
    {
        var getMenuCategory = repository.GetById(id);
        var map = mapper.Map(updateMenuCategory, getMenuCategory);
        repository.TryUpdate(id, map);
        return true;
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchMenuCategoryDto entity)
    {
        var serverSideMenuCategory = repository.GetById(id);
        var serverMenuCategory = serverSideMenuCategory.GetType();
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSideMenuCategory.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSideMenuCategory, value);
            }
        }

        repository.TryUpdate(id, serverSideMenuCategory);
        mapper.Map(serverSideMenuCategory, entity);
        return true;
    }

    public bool TryDelete(Guid id)
    {
        var delete = repository.Delete(id);
        return delete is not null;
    }
}