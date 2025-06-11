using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public class TableRepository(RestaurantContext context) : ITableRepository
{
    private readonly RestaurantContext _context = context;

    public async Task<List<Table>> GetAll()
    {
        return await _context.Tables.ToListAsync();
    }

    public async Task<Table> GetById(Guid id)
    {
        return await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(Table table)
    {
        await _context.Tables.AddAsync(table);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate(Guid id, Table updateTable)
    {
        await _context.Tables
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(table => table.Number, updateTable.Number)
                .SetProperty(table => table.Capacity, updateTable.Capacity)
                .SetProperty(table => table.Type, updateTable.Type));
        return await _context.SaveChangesAsync() > 0;
    }

    public Task<Table> Delete(Guid id)
    {
        var table = GetById(id);
        _context.Tables.Where(x => x.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return table;
    }
}