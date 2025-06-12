using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface IOrderDetailRepository
{
    Task<List<OrderDetail>> GetAll();

    Task<OrderDetail> GetById(Guid id);

    Task<int> Create(OrderDetail table);

    Task<bool> TryUpdate(
        Guid id,
        Guid orderId,
        Guid menuItemId,
        int quantity,
        decimal price,
        OrderDetailStatus status);

    Task<int> Delete(Guid id);
}