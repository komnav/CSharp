using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.DTOs.TableDTOs;

public record UpdateTable(
    int Number,
    int Capacity,
    TableType Type
);