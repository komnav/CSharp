using RestaurantWeb.Model;

namespace RestaurantWeb.Repopsitories;

public class TableRepository : ITableRepository
{
    private static readonly Dictionary<Guid, Table> Tables = [];

    public IEnumerable<Table> GetAll()
    {
        return Tables.Values;
    }

    public Table GetById(Guid id)
    {
        Tables.TryGetValue(id, out var table);
        return table;
    }

    public void Create(Table table)
    {
        Tables.Add(table.Id, table);
    }

    public bool TryUpdate(Guid id, Table updateTable)
    {
        if (!Tables.ContainsKey(id)) return false;
        
        Tables[id] = updateTable;
        return true;
    }

    public Table Delete(Guid id)
    {
        Tables.TryGetValue(id, out var table);
        if (table is not null) 
            Tables.Remove(id);
        
        return table;
    }
}