using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface IMenuCategoryRepository
{
    List<MenuCategory> GetAll();

    MenuCategory GetById(Guid id);

    void Create(MenuCategory table);

    bool TryUpdate(Guid id, MenuCategory updateTable);

    MenuCategory Delete(Guid id);
}