using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public class AccountRepository(RestaurantContext context) : IAccountRepository
{
    private readonly RestaurantContext _context = context;


    public async Task<User> GetById(string userName, string password)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower() && u.Password == password);
    }

    public async Task<int> Create(Contact contact, User user)
    {
        await _context.Users.AddAsync(user);
        await _context.Contacts.AddAsync(contact);
        return await _context.SaveChangesAsync();
    }
}