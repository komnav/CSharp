using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.OrderDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Order")]
public class OrderController(IOrderService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var orderDto = service.GetById(id);
        if (orderDto.TableId < 0)
            return NotFound();
        return Ok(orderDto);
    }

    [HttpGet]
    public List<OrderDto> GetAll()
    {
        return service.GetAll();
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDto orderDto)
    {
        var (validationResult, createOrder) = service.Create(orderDto);
        if (validationResult is not null)
        {
            var errors = validationResult.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }

        return Created($"/api/order/{createOrder.Id}", createOrder);
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
    public IActionResult Update(Guid id, [FromBody] UpdateOrderDto orderDto)
    {
        var result = service.TryUpdate(id, orderDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateOrderDto orderDto)
    {
        var result = service.TryUpdateSpecificProperties(id, orderDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}