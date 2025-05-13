using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class MenuCategoryRepository : IMenuCategoryRepository
{
    private readonly Dictionary<Guid, MenuCategory> _items = [];

    public IEnumerable<MenuCategory> GetAll()
    {
        return _items.Values;
    }

    public MenuCategory GetById(Guid id)
    {
        _items.TryGetValue(id, out var item);
        return item;
    }

    public void Create(MenuCategory table)
    {
        _items.Add(table.Id, table);
    }

    public bool TryUpdate(Guid id, MenuCategory updateTable)
    {
        if (_items.ContainsKey(id))
            _items[id] = updateTable;
        return true;
    }

    public MenuCategory Delete(Guid id)
    {
        _items.TryGetValue(id, out var item);
        _items.Remove(id);
        return item;
    }
}