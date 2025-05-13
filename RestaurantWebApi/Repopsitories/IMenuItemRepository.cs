using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface IMenuItemRepository
{
    IEnumerable<MenuItem> GetAll();

    MenuItem GetById(Guid id);

    void Create(MenuItem table);

    bool TryUpdate(Guid id, MenuItem updateTable);

    MenuItem Delete(Guid id);
}