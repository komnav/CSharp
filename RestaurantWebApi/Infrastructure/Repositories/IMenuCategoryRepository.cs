using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface IMenuCategoryRepository
{
    Task<List<MenuCategory>> GetAll();

    Task<MenuCategory> GetById(Guid id);

    Task<int> Create(MenuCategory table);

    Task<bool> TryUpdate(Guid id, string name, int? parentId);

    Task<int> Delete(Guid id);
}