using RestaurantWeb.DTOs.AccountDTOs.Requests;
using RestaurantWeb.DTOs.AccountDTOs.Responses;

namespace RestaurantWeb.Services;

public interface IAccountService
{
    Task<AuthResponse> Create(RegisterUserRequest request);

    Task<AuthResponse> Login(LoginRequestModel request);
}