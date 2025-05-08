using System.ComponentModel.DataAnnotations;
using RestaurantWeb.Model.Enums;

namespace RestaurantWebApi.DTOs.TableDTOs;

public record CreateTable
{
    [Required, MinLength(1), MaxLength(50)]
    public int Number { get; init; }
    public int Capacity { get; init; }
    public TableType Type { get; init; }
}