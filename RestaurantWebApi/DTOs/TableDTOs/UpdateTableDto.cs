using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.TableDTOs;

public record UpdateTableDto(
    int Number,
    int Capacity,
    TableType Type
);