using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Extensions;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class TableService(
    ITableRepository tableRepository,
    IMapper mapper,
    IServiceProvider serviceProvider)
    : ITableService
{
    public async Task<List<TableDto>> GetAll()
    {
        var table = await tableRepository.GetAll();
        var tableDto = mapper.Map<List<TableDto>>(table);
        return tableDto.Select(s => new TableDto
        {
            Number = s.Number,
            Capacity = s.Capacity,
            Type = s.Type
        }).ToList();
    }

    public async Task<TableDto> GetById(Guid id)
    {
        var serviceSideTable = await tableRepository.GetById(id);
        var result = mapper.Map<TableDto>(serviceSideTable);
        return result;
    }

    public async Task<TableDto> Create(CreateTableDto table)
    {
        var createTable = new Table()
        {
            Number = table.Number,
            Capacity = table.Capacity,
            Type = table.Type
        };
        await tableRepository.Create(createTable);
        var createTableDto = mapper.Map<TableDto>(createTable);
        return new TableDto()
        {
            Number = createTableDto.Number,
            Capacity = createTableDto.Capacity,
            Type = createTableDto.Type
        };
    }

    public async Task<bool> TryUpdate(Guid id, UpdateTableDto updateTable)
    {
        var serviceSideTable = await tableRepository.GetById(id);
        var map = mapper.Map(updateTable, serviceSideTable);
        await tableRepository.TryUpdate(id, map);
        return true;
    }

    public async Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateTableDto entity)
    {
        var serviceTable = await tableRepository.GetById(id);

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

        await tableRepository.TryUpdate(id, serviceTable);
        serviceTable.ToDto();
        return true;
    }

    public async Task<bool> TryDelete(Guid id)
    {
        var deleteTable = await tableRepository.Delete(id);
        return deleteTable is not null;
    }
}