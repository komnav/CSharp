using AutoMapper;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.Model;

namespace RestaurantWeb.Mappers;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>();
        CreateMap<CreateReservationDto, Reservation>();
        CreateMap<UpdateReservationDto, Reservation>();
        CreateMap<PatchUpdateReservationDto, Reservation>();
    }
}