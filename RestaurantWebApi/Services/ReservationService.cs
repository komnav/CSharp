using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.Model;
using RestaurantWeb.Repositories;

namespace RestaurantWeb.Services;

public class ReservationService(
    IReservationRepository reservationRepository,
    IMapper mapper,
    IServiceProvider serviceProvider)
    : IReservationService
{
    public List<ReservationDto> GetAll()
    {
        var reservations = reservationRepository.GetAll();
        var reservationsDto = mapper.Map<List<ReservationDto>>(reservations);
        return reservationsDto;
    }

    public ReservationDto GetById(Guid id)
    {
        var serviceSideReservation = reservationRepository.GetById(id);
        var result = mapper.Map<ReservationDto>(serviceSideReservation);
        return result;
    }

    public (ValidationResult validationResult, ReservationDto dto) Create(CreateReservationDto reservation)
    {
        var validator = serviceProvider.GetService<IValidator<CreateReservationDto>>();
        if (validator != null)
        {
            var result = validator.Validate(reservation);
            if (!result.IsValid)
            {
                return (result, null);
            }
        }

        var createReservation = new Reservation()
        {
            TableId = reservation.TableId,
            From = reservation.From,
            To = reservation.To,
            Notes = reservation.Notes,
            Status = reservation.Status
        };
        reservationRepository.Create(createReservation);
        var createReservationDto = mapper.Map<ReservationDto>(createReservation);
        return (null, createReservationDto);
    }

    public bool TryUpdate(Guid id, UpdateReservationDto updateReservation)
    {
        var serverSidReservation = reservationRepository.GetById(id);
        mapper.Map(updateReservation, serverSidReservation);
        reservationRepository.TryUpdate(id, serverSidReservation);
        return true;
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateReservationDto entity)
    {
        var serverSideReservation = reservationRepository.GetById(id);
        var serverReservation = serverSideReservation.GetType();
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSideReservation.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSideReservation, value);
            }
        }

        reservationRepository.TryUpdate(id, serverSideReservation);
        mapper.Map(serverSideReservation, entity);
        return true;
    }

    public bool TryDelete(Guid id)
    {
        var delete = reservationRepository.Delete(id);
        return delete is not null;
    }
}