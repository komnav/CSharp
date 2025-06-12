using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.ContactDTOs;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class AccountService(
    IAccountRepository repository) : IAccountService
{
    public Task<ContactDto> Create(CreateContactDto contact)
    {
        throw new NotImplementedException();
    }

    public Task<ContactDto> Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}