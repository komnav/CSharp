using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public class OrderRepository(RestaurantContext context) : IOrderRepository
{
    private readonly RestaurantContext _context = context;

    public async Task<List<Order>> GetAll()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetById(Guid id)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(Order order)
    {
        await _context.AddAsync(order);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate(
        Guid id, Guid tableId, Guid foodId, DateTimeOffset dateTime, OrdersStatus status)
    {
        await _context.Orders
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(order => order.TableId, tableId)
                .SetProperty(order => order.FoodId, foodId)
                .SetProperty(order => order.DateTime, dateTime)
                .SetProperty(order => order.Status, status));
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> Delete(Guid id)
    {
        return await _context.Orders.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}