using FluentValidation.Results;
using RestaurantWeb.DTOs.TableDTOs;

namespace RestaurantWeb.Services;

public interface ITableService
{
    Task<List<TableDto>> GetAll();

    Task<TableDto> GetById(Guid id);

    Task<TableDto> Create(CreateTableDto table);

    Task<bool> TryUpdate(Guid id, UpdateTableDto updateTable);

    Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateTableDto entity);

    Task<bool> TryDelete(Guid id);
}