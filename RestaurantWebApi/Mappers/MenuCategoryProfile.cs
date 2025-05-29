using AutoMapper;
using RestaurantWeb.DTOs.MenuCategoryDTOs;
using RestaurantWeb.Model;

namespace RestaurantWeb.Mappers;

public class MenuCategoryProfile : Profile
{
    public MenuCategoryProfile()
    {
        CreateMap<MenuCategory, MenuCategoryDto>();
        CreateMap<CreateMenuCategoryDto, MenuCategory>();
        CreateMap<UpdateMenuCategoryDto, MenuCategory>();
        CreateMap<PatchMenuCategoryDto, MenuCategory>();
    }
}