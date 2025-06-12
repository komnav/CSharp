using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.MenuCategoryDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("MenuCategory")]
public class MenuCategoryController(IMenuCategoryService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var orderDto = await service.GetById(id);
        if (orderDto.Name is null)
            return NotFound();
        return Ok(orderDto);
    }

    [HttpGet]
    public async Task<List<MenuCategoryDto>> GetAll()
    {
        return await service.GetAll();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateMenuCategoryDto menuCategoryDto)
    {
        var create = await service.Create(menuCategoryDto);
        return Ok(create);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMenuCategoryDto menuCategoryDto)
    {
        var result = await service.TryUpdate(id, menuCategoryDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateSpecificProperties(Guid id, PatchMenuCategoryDto menuCategoryDto)
    {
        var result = await service.TryUpdateSpecificProperties(id, menuCategoryDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}