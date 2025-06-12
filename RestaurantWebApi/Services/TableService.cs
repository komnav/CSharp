using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Exceptions;
using RestaurantWeb.Extensions;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Services;

public class TableService(
    ITableRepository tableRepository)
    : ITableService
{
    public async Task<List<TableDto>> GetAll()
    {
        var table = await tableRepository.GetAll();
        return table.Select(s => new TableDto
        {
            Number = s.Number,
            Capacity = s.Capacity,
            Type = s.Type
        }).ToList();
    }

    public async Task<TableDto> GetById(Guid id)
    {
        var table = await tableRepository.GetById(id);
        return new TableDto()
        {
            Number = table.Number,
            Capacity = table.Capacity,
            Type = table.Type
        };
    }

    public async Task<TableDto> Create(CreateTableDto table)
    {
        var createTable = new Table()
        {
            Number = table.Number,
            Capacity = table.Capacity,
            Type = table.Type
        };
        var affectedRows = await tableRepository.Create(createTable);
        if (affectedRows < 0)
        {
            throw new ResourceWasNotCreatedException(nameof(createTable));
        }

        return new TableDto()
        {
            Number = createTable.Number,
            Capacity = createTable.Capacity,
            Type = createTable.Type
        };
    }

    public async Task<bool> TryUpdate(Guid id, UpdateTableDto request)
    {
        var tryToUpdate = await tableRepository.TryUpdate(id, request.Number, request.Capacity, request.Type);
        if (!tryToUpdate)
        {
            throw new ResourceWasNotUpdatedException(nameof(tryToUpdate));
        }

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

        await tableRepository.TryUpdate(id, serviceTable.Number, serviceTable.Capacity, serviceTable.Type);
        serviceTable.ToDto();
        return true;
    }

    public async Task<bool> TryDelete(Guid id)
    {
        var deleteTable = await tableRepository.Delete(id);
        if (deleteTable < 0)
        {
            throw new ResourceWasNotDeletedException(nameof(deleteTable));
        }

        return true;
    }
}