using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public class OrderRepository(RestaurantContext context) : IOrderRepository
{
    private readonly RestaurantContext _context = context;

    public List<Order> GetAll()
    {
        return _context.Orders.ToList();
    }

    public Order GetById(Guid id)
    {
        return _context.Orders.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Order order)
    {
        _context.Add(order);
        _context.SaveChanges();
    }

    public bool TryUpdate(Guid id, Order updatedOrder)
    {
        _context.Orders
            .Where(x => x.Id == id)
            .ExecuteUpdate(x => x
                .SetProperty(order => order.TableId, updatedOrder.TableId)
                .SetProperty(order => order.FoodId, updatedOrder.FoodId)
                .SetProperty(order => order.MenuItem, updatedOrder.MenuItem)
                .SetProperty(order => order.DateTime, updatedOrder.DateTime)
                .SetProperty(order => order.Status, updatedOrder.Status));
        return _context.SaveChanges() > 0;
    }

    public Order Delete(Guid id)
    {
        var order = GetById(id);
        _context.Orders.Where(x => x.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return order;
    }
}