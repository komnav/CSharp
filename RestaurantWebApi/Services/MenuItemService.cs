using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.MenuItemDTOs;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.Exceptions;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class MenuItemService(IMenuItemRepository repository) : IMenuItemService
{
    private readonly IMenuItemRepository _repository = repository;

    public async Task<List<MenuItemDto>> GetAll()
    {
        var reservations = await _repository.GetAll();
        return reservations.Select(s => new MenuItemDto()
        {
            Id = s.Id,
            CategoryId = s.CategoryId,
            Price = s.Price,
            Name = s.Name,
            Status = s.Status
        }).ToList();
    }

    public async Task<MenuItemDto> GetById(Guid id)
    {
        var menuItem = await _repository.GetById(id);
        return new MenuItemDto()
        {
            Id = menuItem.Id,
            CategoryId = menuItem.CategoryId,
            Price = menuItem.Price,
            Name = menuItem.Name,
            Status = menuItem.Status
        };
    }

    public async Task<MenuItemDto> Create(CreateMenuItemDto menuItem)
    {
        var createMenuItem = new MenuItem()
        {
            CategoryId = menuItem.CategoryId,
            Price = menuItem.Price,
            Name = menuItem.Name,
            Status = menuItem.Status
        };
        var create = await _repository.Create(createMenuItem);
        if (create < 0)
            throw new ResourceWasNotCreatedException(nameof(createMenuItem));

        return new MenuItemDto()
        {
            Id = createMenuItem.Id,
            CategoryId = createMenuItem.CategoryId,
            Price = createMenuItem.Price,
            Name = createMenuItem.Name,
            Status = createMenuItem.Status
        };
    }

    public async Task<bool> TryUpdate(Guid id, UpdateMenuItemDto updateMenuItem)
    {
        var update = await _repository.TryUpdate(
            id,
            updateMenuItem.CategoryId,
            updateMenuItem.Price,
            updateMenuItem.Name,
            updateMenuItem.Status);
        if (!update)
            throw new ResourceWasNotUpdatedException(nameof(update));

        return true;
    }

    public async Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto entity)
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
            serverSide.CategoryId,
            serverSide.Price,
            serverSide.Name,
            serverSide.Status);
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