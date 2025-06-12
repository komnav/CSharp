using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.MenuItemDTOs;
using RestaurantWeb.DTOs.OrderDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Order")]
public class OrderController(IOrderService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var orderDto = await service.GetById(id);
        return Ok(orderDto);
    }

    [HttpGet]
    public async Task<List<OrderDto>> GetAll()
    {
        return await service.GetAll();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
    {
        var createOrder = await service.Create(orderDto);
        if (createOrder is null)
        {
            return BadRequest();
        }

        return Created($"/api/order/{createOrder.Id}", createOrder);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderDto orderDto)
    {
        var result = await service.TryUpdate(id, orderDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateSpecificProperties(Guid id, PatchUpdateOrderDto orderDto)
    {
        var result = await service.TryUpdateSpecificProperties(id, orderDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}