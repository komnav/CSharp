using FluentValidation.Results;
using RestaurantWeb.DTOs.ReservationDTOs;

namespace RestaurantWeb.Services;

public interface IReservationService
{
    Task<List<ReservationDto>> GetAll();

    Task<ReservationDto> GetById(Guid id);

    Task<ReservationDto> Create(CreateReservationDto reservation);

    Task<bool> TryUpdate(Guid id, UpdateReservationDto updateReservation);

    Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateReservationDto entity);

    Task<bool> TryDelete(Guid id);
}