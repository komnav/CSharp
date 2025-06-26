using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface IAccountRepository
{
    Task<User> GetById(string userName, string password);

    Task<int> Create(Contact contact, User user);

    Task<int> Delete(string userName, string userRole);
}