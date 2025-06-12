using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.Exceptions;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class ReservationService(IReservationRepository reservationRepository)
    : IReservationService
{
    public async Task<List<ReservationDto>> GetAll()
    {
        var reservations = await reservationRepository.GetAll();
        return reservations.Select(s => new ReservationDto()
        {
            Id = s.Id,
            TableId = s.TableId,
            From = s.From,
            To = s.To,
            Notes = s.Notes,
            Status = s.Status
        }).ToList();
    }

    public async Task<ReservationDto> GetById(Guid id)
    {
        var reservation = await reservationRepository.GetById(id);
        return new ReservationDto()
        {
            Id = reservation.Id,
            TableId = reservation.TableId,
            From = reservation.From,
            To = reservation.To,
            Notes = reservation.Notes,
            Status = reservation.Status
        };
    }

    public async Task<ReservationDto> Create(CreateReservationDto reservation)
    {
        var createReservation = new Reservation()
        {
            TableId = reservation.TableId,
            From = reservation.From,
            To = reservation.To,
            Notes = reservation.Notes,
            Status = reservation.Status
        };
        var create = await reservationRepository.Create(createReservation);
        if (create < 0)
            throw new ResourceWasNotCreatedException(nameof(createReservation));

        return new ReservationDto()
        {
            Id = createReservation.Id,
            TableId = createReservation.TableId,
            From = createReservation.From,
            To = createReservation.To,
            Notes = createReservation.Notes,
            Status = createReservation.Status
        };
    }

    public async Task<bool> TryUpdate(Guid id, UpdateReservationDto updateReservation)
    {
        var update = await reservationRepository.TryUpdate(
            id,
            updateReservation.TableId,
            updateReservation.CustomerId,
            updateReservation.From,
            updateReservation.To,
            updateReservation.Notes,
            updateReservation.Status);
        if (!update)
            throw new ResourceWasNotUpdatedException(nameof(updateReservation));

        return true;
    }

    public async Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateReservationDto entity)
    {
        var serverSide = await reservationRepository.GetById(id);
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSide.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSide, value);
            }
        }

        var update = await reservationRepository.TryUpdate(
            id,
            serverSide.TableId,
            serverSide.UserId,
            serverSide.From,
            serverSide.To,
            serverSide.Notes,
            serverSide.Status);
        if (!update)
            throw new ResourceWasNotUpdatedException(nameof(entity));

        return true;
    }

    public async Task<bool> TryDelete(Guid id)
    {
        var delete = await reservationRepository.Delete(id);
        if (delete < 0)
            return false;
        return true;
    }
}