using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Model;
using RestaurantWeb.Repositories;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("api/Reservation")]
public class ReservationController : ControllerBase
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationController(IReservationRepository reservationRepository, [FromServices] IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var getReservationById = _reservationRepository.GetById(id);
        var result = _mapper.Map<ReservationDto>(getReservationById);
        return Ok(result);
    }

    [HttpGet]
    public IEnumerable<ReservationDto> GetAll()
    {
        var getReservation = _reservationRepository.GetAll();
        var result = _mapper.Map<IEnumerable<ReservationDto>>(getReservation);
        return result;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateReservationDto reservationDto)
    {
        var createReservation = new Reservation
        {
            Id = Guid.NewGuid(),
            TableId = reservationDto.TableId,
            From = reservationDto.From,
            To = reservationDto.To,
            Notes = reservationDto.Notes,
            Status = reservationDto.Status
        };
        _reservationRepository.Create(createReservation);
        return Ok(createReservation);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var deleteReservation = _reservationRepository.Delete(id);
        var result = _mapper.Map<ReservationDto>(deleteReservation);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(Guid id, [FromBody] UpdateReservationDto reservationDto)
    {
        var reservationForUpdate = _reservationRepository.GetById(id);
        if (reservationForUpdate == null) throw new Exception("Not found");

        reservationForUpdate.TableId = reservationDto.TableId;
        reservationForUpdate.From = reservationDto.From;
        reservationForUpdate.To = reservationDto.To;
        reservationForUpdate.Notes = reservationDto.Notes;
        reservationForUpdate.Status = reservationDto.Status;

        var result = _mapper.Map(reservationForUpdate, reservationForUpdate);
        return Ok(result);
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateReservationDto reservationDto)
    {
        var serviceReservation = _reservationRepository.GetById(id);
        var serviceReservationType = serviceReservation.GetType();
        var properties = reservationDto.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(reservationDto);
            if (value is not null)
            {
                var oldProperty = serviceReservationType.GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serviceReservation, value);
            }
        }

        var updateReservation = _reservationRepository.TryUpdate(id, serviceReservation);
        var result = _mapper.Map<ReservationDto>(updateReservation);
        return Ok(result);
    }
}