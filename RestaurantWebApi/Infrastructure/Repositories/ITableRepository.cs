using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface ITableRepository
{
    List<Table> GetAll();

    Table GetById(Guid id);

    void Create(Table table);

    bool TryUpdate(Guid id, Table updateTable);

    Table Delete(Guid id);
}