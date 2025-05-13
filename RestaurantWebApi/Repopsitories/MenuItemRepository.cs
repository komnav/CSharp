using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly Dictionary<Guid, MenuItem> _items = [];

    public IEnumerable<MenuItem> GetAll()
    {
        return _items.Values;
    }

    public MenuItem GetById(Guid id)
    {
        _items.TryGetValue(id, out var item);
        return item;
    }

    public void Create(MenuItem table)
    {
        _items.Add(table.Id, table);
    }

    public bool TryUpdate(Guid id, MenuItem updateTable)
    {
        if (!_items.ContainsKey(id))
            _items[id] = updateTable;
        return true;
    }

    public MenuItem Delete(Guid id)
    {
        _items.TryGetValue(id, out var item);
        if (item is not null)
            _items.Remove(id);
        return item;
    }
}