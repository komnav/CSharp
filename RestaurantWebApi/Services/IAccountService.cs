using RestaurantWeb.DTOs.AccountDTOs.Requests;
using RestaurantWeb.DTOs.AccountDTOs.Responses;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public interface IAccountService
{
    Task<AuthResponse> Create(RegisterUserRequest request);

    Task<AuthResponse> Login(LoginRequestModel request);

    string CreateToken(User user);

    Task<int> DeleteUserByRole(string userName, string role);
}