using AutoMapper;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Model;

namespace RestaurantWeb.Mappers;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<Table, TableDto>();
        CreateMap<CreateTableDto, Table>();
        CreateMap<UpdateTableDto, Table>();
        CreateMap<PatchUpdateTableDto, Table>();
    }
}