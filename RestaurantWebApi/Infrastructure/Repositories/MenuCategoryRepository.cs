using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public class MenuCategoryRepository(RestaurantContext context) : IMenuCategoryRepository
{
    private readonly RestaurantContext _context = context;

    public async Task<List<MenuCategory>> GetAll()
    {
        return await _context.MenuCategories.ToListAsync();
    }

    public async Task<MenuCategory> GetById(Guid id)
    {
        return await _context.MenuCategories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(MenuCategory menuCategory)
    {
        await _context.AddAsync(menuCategory);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate(Guid id, string name, int? parentId)
    {
        await _context.MenuCategories
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(category => category.Name, name)
                .SetProperty(category => category.ParentId, parentId));
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> Delete(Guid id)
    {
        return await _context.MenuItems.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}