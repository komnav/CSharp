using FluentValidation.Results;
using RestaurantWeb.DTOs.ReservationDTOs;

namespace RestaurantWeb.Services;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetAll();

    ReservationDto GetById(Guid id);

    (ValidationResult validationResult, ReservationDto dto) Create(CreateReservationDto reservation);

    bool TryUpdate(Guid id, UpdateReservationDto updateReservation);

    bool TryUpdateSpecificProperties(Guid id, PatchUpdateReservationDto entity);

    bool TryDelete(Guid id);
}