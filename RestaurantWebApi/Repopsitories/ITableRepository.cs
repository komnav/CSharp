using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface ITableRepository:IRepository<Table>
{
    IEnumerable<Table> TheBestTables(int count);
}