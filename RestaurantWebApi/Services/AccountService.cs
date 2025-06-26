using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantWeb.DTOs;
using RestaurantWeb.DTOs.AccountDTOs.Requests;
using RestaurantWeb.DTOs.AccountDTOs.Responses;
using RestaurantWeb.Exceptions;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Services;

public class AccountService(IAccountRepository repository, IOptions<JwtSettingsOptions> jwtSettingsOptions)
    : IAccountService
{
    private readonly IAccountRepository _repository = repository;
    private readonly JwtSettingsOptions _jwtSettingsOptions = jwtSettingsOptions.Value;

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
        if (create <= 0)
            throw new ResourceWasNotCreatedException($"User: {user.UserName} was not created");
        
        var token = CreateToken(user);

        return new AuthResponse { Token = token };
    }

    public string CreateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettingsOptions.Key);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Role),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(_jwtSettingsOptions.TokenLifetime),
            Issuer = _jwtSettingsOptions.Issuer,
            Audience = _jwtSettingsOptions.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<AuthResponse> Login(LoginRequestModel request)
    {
        var getUser = await _repository.GetById(request.UserName, request.Password);
        if (getUser == null)
        {
            return null;
        }

        var newToken = CreateToken(getUser);

        return new AuthResponse()
        {
            Token = newToken
        };
    }
}