using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _orders = [];

    public IEnumerable<Order> GetAll()
    {
        return _orders.Values;
    }

    public Order GetById(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        return order;
    }

    public void Create(Order table)
    {
        _orders.Add(table.Id, table);
    }

    public bool TryUpdate(Guid id, Order updateTable)
    {
        if (_orders.ContainsKey(id)) return false;
        _orders[id] = updateTable;
        return true;
    }

    public Order Delete(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        if (order is not null)
            _orders.Remove(id);
        return order;
    }
}