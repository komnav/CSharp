using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Extensions;
using RestaurantWeb.Model;
using RestaurantWeb.Repositories;

namespace RestaurantWeb.Services;

public class TableService(
    ITableRepository tableRepository,
    IMapper mapper,
    IServiceProvider serviceProvider)
    : ITableService
{
    public List<TableDto> GetAll()
    {
        var table = tableRepository.GetAll();
        var tableDto = mapper.Map<List<TableDto>>(table);
        return tableDto;
    }

    public TableDto GetById(Guid id)
    {
        var serviceSideTable = tableRepository.GetById(id);
        var result = mapper.Map<TableDto>(serviceSideTable);
        return result;
    }

    public (ValidationResult validationResult, TableDto dto) Create(CreateTableDto table)
    {
        var validator = serviceProvider.GetService<IValidator<CreateTableDto>>();
        if (validator != null)
        {
            var result = validator.Validate(table);
            if (!result.IsValid)
            {
                return (result, null);
            }
        }

        var createTable = new Table()
        {
            Number = table.Number,
            Capacity = table.Capacity,
            Type = table.Type
        };
        tableRepository.Create(createTable);
        var createTableDto = mapper.Map<TableDto>(createTable);
        return (null, createTableDto);
    }

    public bool TryUpdate(Guid id, UpdateTableDto updateTable)
    {
        var serviceSideTable = tableRepository.GetById(id);
        mapper.Map(updateTable, serviceSideTable);
        tableRepository.TryUpdate(id, serviceSideTable);
        return true;
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateTableDto entity)
    {
        var serviceTable = tableRepository.GetById(id);

        var serviceTableType = serviceTable.GetType();
        var properties = entity.GetType().GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serviceTableType.GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serviceTable, value);
            }
        }

        tableRepository.TryUpdate(id, serviceTable);
        serviceTable.ToDto();
        return true;
    }

    public bool TryDelete(Guid id)
    {
        var deleteTable = tableRepository.Delete(id);
        return deleteTable is not null;
    }
}