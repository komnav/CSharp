using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetAll();

    Task<Order> GetById(Guid id);

    Task<int> Create(Order table);

    Task<bool> TryUpdate(Guid id, Guid tableId, Guid foodId, DateTimeOffset dateTime, OrdersStatus ordersStatus);

    Task<int> Delete(Guid id);
}