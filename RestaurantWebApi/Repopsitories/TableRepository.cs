using Microsoft.EntityFrameworkCore;
using RestaurantWeb.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class TableRepository(RestaurantContext context) : ITableRepository
{
    private readonly RestaurantContext _context = context;

    public List<Table> GetAll()
    {
        return _context.Tables.ToList();
    }

    public Table GetById(Guid id)
    {
        return _context.Tables.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Table table)
    {
        _context.Add(table);
        _context.SaveChanges();
    }

    public bool TryUpdate(Guid id, Table updateTable)
    {
        _context.Tables
            .Where(x => x.Id == id)
            .ExecuteUpdate(x => x
                .SetProperty(table => table.Number, updateTable.Number)
                .SetProperty(table => table.Capacity, updateTable.Capacity)
                .SetProperty(table => table.Type, updateTable.Type));
        return _context.SaveChanges() > 0;
    }

    public Table Delete(Guid id)
    {
        var table = GetById(id);
        _context.Tables.Where(x => x.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return table;
    }
}