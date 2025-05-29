using AutoMapper;
using RestaurantWeb.DTOs.OrderDTOs;
using RestaurantWeb.Model;

namespace RestaurantWeb.Mappers;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<CreateOrderDto, Order>();
        CreateMap<UpdateOrderDto, Order>();
        CreateMap<PatchUpdateOrderDto, Order>();
    }
}