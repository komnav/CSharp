using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class TableRepository : Repository<Table>, ITableRepository
{
    public IEnumerable<Table> TheBestTables(int count)
    {
        throw new NotImplementedException();
    }
}