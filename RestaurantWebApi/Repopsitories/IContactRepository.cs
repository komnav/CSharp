using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface IContactRepository
{
    IEnumerable<Contact> GetAll();

    Contact GetById(Guid id);

    void Create(Contact table);

    bool TryUpdate(Guid id, Contact updateTable);

    Contact Delete(Guid id);
}