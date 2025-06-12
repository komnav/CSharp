using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public class OrderDetailRepository(RestaurantContext context) : IOrderDetailRepository
{
    private readonly RestaurantContext _context = context;

    public async Task<List<OrderDetail>> GetAll()
    {
        return await _context.OrderDetails.ToListAsync();
    }

    public async Task<OrderDetail> GetById(Guid id)
    {
        return await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(OrderDetail table)
    {
        await _context.OrderDetails.AddAsync(table);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate(
        Guid id,
        Guid orderId,
        Guid menuItemId,
        int quantity,
        decimal price,
        OrderDetailStatus status)
    {
        await _context.OrderDetails.Where(x => x.Id == id)
            .ExecuteUpdateAsync(x =>
                x.SetProperty(x => x.OrderId, orderId)
                    .SetProperty(x => x.MenuItemId, menuItemId)
                    .SetProperty(x => x.Quantity, quantity)
                    .SetProperty(x => x.Price, price)
            );
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> Delete(Guid id)
    {
        return
            await _context.OrderDetails.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}