using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Model;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("api/Reservation")]
public class ReservationController(IReservationService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var reservation = await service.GetById(id);
        return Ok(reservation);
    }

    [HttpGet]
    public async Task<List<ReservationDto>> GetAll()
    {
        return await service.GetAll();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservationDto reservationDto)
    {
        var createReservation = await service.Create(reservationDto);
        if (createReservation is null)
        {
            return BadRequest();
        }

        return Created($"/api/table/{createReservation.Id}", createReservation);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservationDto reservationDto)
    {
        var result = await service.TryUpdate(id, reservationDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateSpecificProperties(Guid id, PatchUpdateReservationDto reservationDto)
    {
        var result = await service.TryUpdateSpecificProperties(id, reservationDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}