using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.MenuItemDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("MenuItem")]
public class MenuItemController(IMenuItemService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var menuItem = await service.GetById(id);
        if (menuItem.Name is null)
            return NotFound();
        return Ok(menuItem);
    }

    [HttpGet]
    public async Task<List<MenuItemDto>> GetAll()
    {
        return await service.GetAll();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateMenuItemDto itemDto)
    {
        var createdItem = await service.Create(itemDto);

        return Created($"/api/menuItem/{createdItem.Id}", createdItem);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await service.TryDelete(id);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMenuItemDto menuItemDto)
    {
        var result = await service.TryUpdate(id, menuItemDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto menuItemDto)
    {
        var result = await service.TryUpdateSpecificProperties(id, menuItemDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}