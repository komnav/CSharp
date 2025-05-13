using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly Dictionary<Guid, Contact> _contacts = [];

    public IEnumerable<Contact> GetAll()
    {
        return _contacts.Values;
    }

    public Contact GetById(Guid id)
    {
        _contacts.TryGetValue(id, out var contact);
        return contact;
    }

    public void Create(Contact table)
    {
        _contacts.Add(table.Id, table);
    }

    public bool TryUpdate(Guid id, Contact updateTable)
    {
        if (_contacts.ContainsKey(id))
            _contacts[id] = updateTable;
        return true;
    }

    public Contact Delete(Guid id)
    {
        _contacts.TryGetValue(id, out var contact);
        _contacts.Remove(id);
        return contact;
    }
}