using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Table")]
public class TableController(ITableService tableService) : ControllerBase
{
    [HttpGet]
    public Task GetAll()
    {
        return tableService.GetAll();
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var table = tableService.GetById(id);
        if (table is null)
            return NotFound();
        return Ok(table);
    }

    [HttpPost]
    public IActionResult Create(CreateTableDto createTableDto)
    {
        var createTable = tableService.Create(createTableDto);
        if (createTable is null)
        {
            return BadRequest();
        }

        return Created($"/api/table/{createTable.Id}", createTable);
    }

    [HttpPut]
    public IActionResult Update(Guid id, UpdateTableDto updateTableDto)
    {
        var table = tableService.TryUpdate(id, updateTableDto);
        if (table.Result == false)
            return NotFound();
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateTableDto updateTableDto)
    {
        var result = tableService.TryUpdateSpecificProperties(id, updateTableDto);
        if (result.Result == false)
            return NotFound();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var deleteTable = tableService.TryDelete(id);
        if (deleteTable.Result == false)
            return NotFound();
        return Ok();
    }
}