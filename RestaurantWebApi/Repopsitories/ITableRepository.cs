using RestaurantWeb.Model;
using RestaurantWebApi.DTOs.TableDTOs;

namespace RestaurantWeb.Repopsitories;

public interface ITableRepository
{
    IEnumerable<Table> GetAll();

    Table GetById(Guid id);

    void Create(Table table);

    bool TryUpdate(Guid id, Table updateTable);

    Table Delete(Guid id);
}