using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Model;
using RestaurantWeb.Repositories;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("api/Reservation")]
public class ReservationController(IReservationService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var getReservationById = service.GetById(id);
        return Ok(getReservationById);
    }

    [HttpGet]
    public IEnumerable<ReservationDto> GetAll()
    {
        var getReservation = service.GetAll();
        return getReservation;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateReservationDto reservationDto)
    {
        var (validationResult, createReservation) = service.Create(reservationDto);
        if (validationResult is not null)
        {
            var errors = validationResult.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }

        return Ok(createReservation);
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
    public IActionResult Update(Guid id, [FromBody] UpdateReservationDto reservationDto)
    {
        var result = service.TryUpdate(id, reservationDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateReservationDto reservationDto)
    {
        var result = service.TryUpdateSpecificProperties(id, reservationDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}