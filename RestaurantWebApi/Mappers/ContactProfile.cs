using AutoMapper;
using RestaurantWeb.DTOs.ContactDTOs;
using RestaurantWeb.Model;

namespace RestaurantWeb.Mappers;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactDto>();
        CreateMap<CreateContactDto, Contact>();
        CreateMap<UpdateContactDto, Contact>();
        CreateMap<PatchUpdateContactDto, Contact>();
    }
}