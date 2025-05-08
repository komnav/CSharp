using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Extensions;
using RestaurantWeb.Model;
using RestaurantWeb.Repopsitories;
using RestaurantWebApi.DTOs.TableDTOs;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Table")]
public class TableController : Controller
{
    [HttpGet]
    public IEnumerable<TableDto> GetAll([FromServices] ITableRepository tableRepository)
    {
        return tableRepository.GetAll().Select(c => c.ToDto());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id, [FromServices] ITableRepository tableRepository)
    {
        var table = tableRepository.GetById(id);
        return Ok(table.ToDto());
    }

    [HttpPost]
    public IActionResult Create(
        CreateTable createTable,
        [FromServices] ITableRepository tableRepository
    )
    {
        var createTables = new Table
        {
            Id = Guid.NewGuid(),
            Number = createTable.Number,
            Capacity = createTable.Capacity,
            Type = createTable.Type
        };
        tableRepository.Create(createTables);
        return Created($"/api/client/{createTable.Number}", createTable);
    }

    [HttpPut]
    public IActionResult Update(
        Guid id, UpdateTable updateTable,
        [FromServices] ITableRepository tableRepository)
    {
        var table = tableRepository.GetById(id);

        table.Number = updateTable.Number;
        table.Capacity = updateTable.Capacity;
        table.Type = updateTable.Type;

        tableRepository.TryUpdate(id, table);
        return Ok(table.ToDto());
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(
        Guid id, PatchUpdateTable updateTable,
        [FromServices] ITableRepository tableRepository)
    {
        var serviceTable = tableRepository.GetById(id);

        var serviceTableType = serviceTable.GetType();
        var properties = updateTable.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(updateTable);
            if (value is not null)
            {
                var oldProperty = serviceTableType.GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serviceTable, value);
            }
        }

        tableRepository.TryUpdate(id, serviceTable);
        return Ok(serviceTable.ToDto());
    }

    [HttpDelete]
    public IActionResult Delete(Guid id, [FromServices] ITableRepository tableRepository)
    {
        var deleteTable = tableRepository.Delete(id);
        return Ok(deleteTable.ToDto());
    }
}