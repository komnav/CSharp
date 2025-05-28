using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface IContactRepository
{
    List<Contact> GetAll();

    Contact GetById(Guid id);

    void Create(Contact table);

    bool TryUpdate(Guid id, Contact updateTable);

    Contact Delete(Guid id);
}