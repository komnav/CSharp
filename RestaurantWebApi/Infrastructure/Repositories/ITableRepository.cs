using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface ITableRepository
{
    Task<List<Table>> GetAll();

    Task<Table> GetById(Guid id);

    Task<int> Create(Table table);

    Task<bool> TryUpdate(Guid id, int number, int capacity, TableType type);

    Task<int> Delete(Guid id);
}