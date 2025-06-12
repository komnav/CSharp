using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public class MenuItemRepository(RestaurantContext context) : IMenuItemRepository
{
    private readonly RestaurantContext _context = context;

    public async Task<List<MenuItem>> GetAll()
    {
        return await _context.MenuItems.ToListAsync();
    }

    public async Task<MenuItem> GetById(Guid id)
    {
        return await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(MenuItem menuItem)
    {
        await _context.AddAsync(menuItem);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate(Guid id, Guid categoryId, decimal price, string name, MenuItemStatus status)
    {
        await _context.MenuItems
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(item => item.CategoryId, categoryId)
                .SetProperty(item => item.Price, price)
                .SetProperty(item => item.Name, name)
                .SetProperty(item => item.Status, status));
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> Delete(Guid id)
    {
        return await _context.MenuItems.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}