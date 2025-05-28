using Microsoft.EntityFrameworkCore;
using RestaurantWeb.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class ContactRepository(RestaurantContext context) : IContactRepository
{
    private readonly RestaurantContext _context = context;

    public List<Contact> GetAll()
    {
        return _context.Contacts.ToList();
    }

    public Contact GetById(Guid id)
    {
        return _context.Contacts.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Contact contact)
    {
        _context.Add(context);
        _context.SaveChanges();
    }

    public bool TryUpdate(Guid id, Contact updateContact)
    {
        _context.Contacts
            .Where(x => x.Id == id)
            .ExecuteUpdate(x => x
                .SetProperty(contact => contact.FirstName, updateContact.FirstName)
                .SetProperty(contact => contact.LastName, updateContact.LastName)
                .SetProperty(contact => contact.Email, updateContact.Email)
                .SetProperty(contact => contact.PhoneNumber, updateContact.PhoneNumber)
                .SetProperty(contact => contact.Address, updateContact.Address));
        return _context.SaveChanges() > 0;
    }

    public Contact Delete(Guid id)
    {
        var contact = GetById(id);
        _context.Contacts.Where(x => x.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return contact;
    }
}