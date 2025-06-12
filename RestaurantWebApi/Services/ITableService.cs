using FluentValidation.Results;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Services;

public interface ITableService
{
    Task<List<TableDto>> GetAll();

    Task<TableDto> GetById(Guid id);

    Task<TableDto> Create(CreateTableDto table);

    Task<bool> TryUpdate(Guid id, int number, int capacity, TableType type);

    Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateTableDto entity);

    Task<bool> TryDelete(Guid id);
}