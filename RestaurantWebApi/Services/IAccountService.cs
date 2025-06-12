using RestaurantWeb.DTOs.ContactDTOs;
using FluentValidation.Results;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public interface IAccountService
{
    Task<ContactDto> Create(CreateContactDto contact);
    
    Task<ContactDto> Login(string username, string password);
}