using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();

    Order GetById(Guid id);

    void Create(Order table);

    bool TryUpdate(Guid id, Order updateTable);

    Order Delete(Guid id);
}