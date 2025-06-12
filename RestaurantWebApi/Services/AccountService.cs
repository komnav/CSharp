using RestaurantWeb.DTOs.AccountDTOs.Requests;
using RestaurantWeb.DTOs.AccountDTOs.Responses;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Services;

public class AccountService(IAccountRepository repository) : IAccountService
{
    private readonly IAccountRepository _repository = repository;

    public async Task<AuthResponse> Create(RegisterUserRequest request)
    {
        var contact = new Contact
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var user = new User
        {
            UserName = request.UserName,
            Password = request.Password,
            Role = UserRoles.Customer,
            Contact = contact
        };

        var create = await _repository.Create(contact, user);
        if (create > 0)
        {
            return new AuthResponse()
            {
                Token = true,
            };
        }

        return new AuthResponse()
        {
            Token = false,
        };
    }

    public async Task<AuthResponse> Login(LoginRequestModel request)
    {
        var getUser = await _repository.GetById(request.UserName, request.Password);
        if (getUser == null)
        {
            return null;
        }

        return new AuthResponse()
        {
            Token = true
        };
    }
}