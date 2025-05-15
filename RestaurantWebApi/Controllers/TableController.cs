using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Table")]
public class TableController(ITableService tableService) : ControllerBase
{
    [HttpGet]
    public IEnumerable<TableDto> GetAll()
    {
        return tableService.GetAll();
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var table = tableService.GetById(id);
        if (table.Number < 0)
            return NotFound();
        return Ok(table);
    }

    [HttpPost]
    public IActionResult Create(CreateTableDto createTableDto)
    {
        var (validationResult, createTable) = tableService.Create(createTableDto);
        if (validationResult is not null)
        {
            var errors = validationResult.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }
        return Created($"/api/client/{createTable.Id}", createTable);
    }

    [HttpPut]
    public IActionResult Update(Guid id, UpdateTableDto updateTableDto)
    {
        var table = tableService.TryUpdate(id, updateTableDto);
        if (!table)
            return NotFound();
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateTableDto updateTableDto)
    {
        var result = tableService.TryUpdateSpecificProperties(id, updateTableDto);
        if (!result)
            return NotFound();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var deleteTable = tableService.TryDelete(id);
        if (!deleteTable)
            return NotFound();
        return Ok();
    }
}