using AutoMapper;
using RestaurantWeb.DTOs.MenuItemDTOs;
using RestaurantWeb.Model;

namespace RestaurantWeb.Mappers;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItem, MenuItemDto>();
        CreateMap<CreateMenuItemDto, MenuItem>();
        CreateMap<UpdateMenuItemDto, MenuItem>();
        CreateMap<PatchUpdateMenuItemDto, MenuItem>();
    }
}