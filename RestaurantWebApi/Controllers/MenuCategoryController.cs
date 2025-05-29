using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.MenuCategoryDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("MenuCategory")]
public class MenuCategoryController(IMenuCategoryService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var orderDto = service.GetById(id);
        if (orderDto.Name is null)
            return NotFound();
        return Ok(orderDto);
    }

    [HttpGet]
    public List<MenuCategoryDto> GetAll()
    {
        return service.GetAll();
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateMenuCategoryDto menuCategoryDto)
    {
        var (validationResult, createMenuCategory) = service.Create(menuCategoryDto);
        if (validationResult is not null)
        {
            var errors = validationResult.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }

        return Created($"/api/menuCategory/{createMenuCategory.Id}", createMenuCategory);
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
    public IActionResult Update(Guid id, [FromBody] UpdateMenuCategoryDto menuCategoryDto)
    {
        var result = service.TryUpdate(id, menuCategoryDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchMenuCategoryDto menuCategoryDto)
    {
        var result = service.TryUpdateSpecificProperties(id, menuCategoryDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}