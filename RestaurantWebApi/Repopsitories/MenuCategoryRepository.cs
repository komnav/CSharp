using Microsoft.EntityFrameworkCore;
using RestaurantWeb.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class MenuCategoryRepository(RestaurantContext context) : IMenuCategoryRepository
{
    private readonly RestaurantContext _context = context;

    public List<MenuCategory> GetAll()
    {
        return _context.MenuCategories.ToList();
    }

    public MenuCategory GetById(Guid id)
    {
        return _context.MenuCategories.FirstOrDefault(x => x.Id == id);
    }

    public void Create(MenuCategory menuCategory)
    {
        _context.Add(menuCategory);
        _context.SaveChanges();
    }

    public bool TryUpdate(Guid id, MenuCategory updateMenuCategory)
    {
        _context.MenuCategories
            .Where(x => x.Id == id)
            .ExecuteUpdate(x => x
                .SetProperty(category => category.Name, updateMenuCategory.Name)
                .SetProperty(category => category.ParentId, updateMenuCategory.ParentId));
        return _context.SaveChanges() > 0;
    }

    public MenuCategory Delete(Guid id)
    {
        var menuCategory = GetById(id);
        _context.MenuCategories.Where(x => x.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return menuCategory;
    }
}