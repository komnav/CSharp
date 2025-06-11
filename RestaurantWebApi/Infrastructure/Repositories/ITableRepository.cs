using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface ITableRepository
{
    Task<List<Table>> GetAll();

    Task<Table> GetById(Guid id);

    Task<int> Create(Table table);

    Task<bool> TryUpdate(Guid id, Table updateTable);

    Task<Table> Delete(Guid id);
}