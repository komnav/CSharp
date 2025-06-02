using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public class MenuItemRepository(RestaurantContext context) : IMenuItemRepository
{
    private readonly RestaurantContext _context = context;

    public List<MenuItem> GetAll()
    {
        return _context.MenuItems.ToList();
    }

    public MenuItem GetById(Guid id)
    {
        return _context.MenuItems.FirstOrDefault(x => x.Id == id);
    }

    public void Create(MenuItem menuItem)
    {
        _context.Add(menuItem);
        _context.SaveChanges();
    }

    public bool TryUpdate(Guid id, MenuItem updatedItem)
    {
        _context.MenuItems
            .Where(x => x.Id == id)
            .ExecuteUpdate(x => x
                .SetProperty(item => item.CategoryId, updatedItem.CategoryId)
                .SetProperty(item => item.Price, updatedItem.Price)
                .SetProperty(item => item.Name, updatedItem.Name)
                .SetProperty(item => item.Status, updatedItem.Status));
        return _context.SaveChanges() > 0;
    }

    public MenuItem Delete(Guid id)
    {
        var item = GetById(id);
        _context.MenuItems.Where(x => x.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return item;
    }
}