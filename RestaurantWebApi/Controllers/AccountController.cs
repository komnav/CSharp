using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.AccountDTOs.Requests;
using RestaurantWeb.DTOs.AccountDTOs.Responses;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Contact")]
public class AccountController(IAccountService service) : ControllerBase
{
    [HttpPost("register")]
    public async Task<AuthResponse> Create([FromBody] RegisterUserRequest request)
    {
        return await service.Create(request);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
    {
        var getUser = await service.Login(request);
        if (getUser == null)
        {
            return Unauthorized();
        }

        return Ok(getUser.Token);
    }
}