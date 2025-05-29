using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.MenuItemDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("MenuItem")]
public class MenuItemController(IMenuItemService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var menuItem = service.GetById(id);
        if (menuItem.Name is null)
            return NotFound();
        return Ok(menuItem);
    }

    [HttpGet]
    public List<MenuItemDto> GetAll()
    {
        return service.GetAll();
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateMenuItemDto itemDto)
    {
        var (validationResult, createMeniTem) = service.Create(itemDto);
        if (validationResult is not null)
        {
            var errors = validationResult.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }

        return Created($"/api/menuItem/{createMeniTem.Id}", createMeniTem);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var result = service.TryDelete(id);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Guid id, [FromBody] UpdateMenuItemDto menuItemDto)
    {
        var result = service.TryUpdate(id, menuItemDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateMenuItemDto menuItemDto)
    {
        var result = service.TryUpdateSpecificProperties(id, menuItemDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}