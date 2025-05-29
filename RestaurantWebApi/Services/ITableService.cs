using FluentValidation.Results;
using RestaurantWeb.DTOs.TableDTOs;

namespace RestaurantWeb.Services;

public interface ITableService
{
    List<TableDto> GetAll();

    TableDto GetById(Guid id);

    (ValidationResult validationResult, TableDto dto) Create(CreateTableDto table);

    bool TryUpdate(Guid id, UpdateTableDto updateTable);

    bool TryUpdateSpecificProperties(Guid id, PatchUpdateTableDto entity);

    bool TryDelete(Guid id);
}