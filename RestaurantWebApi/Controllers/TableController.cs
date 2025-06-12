using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Table")]
public class TableController(ITableService tableService) : ControllerBase
{
    [HttpGet]
    public async Task<List<TableDto>> GetAll()
    {
        return await tableService.GetAll();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var table = await tableService.GetById(id);
        if (table is null)
            return NotFound();
        return Ok(table);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTableDto createTableDto)
    {
        var createTable = await tableService.Create(createTableDto);
        if (createTable is null)
        {
            return BadRequest();
        }

        return Created($"/api/table/{createTable.Id}", createTable);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, UpdateTableDto updateTableDto)
    {
        var table = await tableService.TryUpdate(id, updateTableDto);
        if (!table)
            return NotFound();
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateSpecificProperties(Guid id, PatchUpdateTableDto updateTableDto)
    {
        var result = await tableService.TryUpdateSpecificProperties(id, updateTableDto);
        if (!result)
            return NotFound();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteTable = await tableService.TryDelete(id);
        if (!deleteTable)
            return NotFound();
        return Ok();
    }
}