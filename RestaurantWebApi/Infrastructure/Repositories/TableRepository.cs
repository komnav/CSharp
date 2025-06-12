using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

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

    public async Task<bool> TryUpdate(Guid id, int number, int capacity, TableType type)
    {
        await _context.Tables
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(table => table.Number, number)
                .SetProperty(table => table.Capacity, capacity)
                .SetProperty(table => table.Type, type));
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> Delete(Guid id)
    {
        return await _context.Tables
            .Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}