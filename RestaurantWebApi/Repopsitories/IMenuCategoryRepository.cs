using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface IMenuCategoryRepository
{
    IEnumerable<MenuCategory> GetAll();

    MenuCategory GetById(Guid id);

    void Create(MenuCategory table);

    bool TryUpdate(Guid id, MenuCategory updateTable);

    MenuCategory Delete(Guid id);
}