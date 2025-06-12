using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetAll();

    Task<MenuItem> GetById(Guid id);

    Task<int> Create(MenuItem table);

    Task<bool> TryUpdate(Guid id, Guid categoryId, decimal price, string name, MenuItemStatus status);

    Task<int> Delete(Guid id);
}