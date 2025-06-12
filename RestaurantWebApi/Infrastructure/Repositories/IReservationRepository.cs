using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public interface IReservationRepository
{
    Task<List<Reservation>> GetAll();

    Task<Reservation> GetById(Guid id);

    Task<int> Create(Reservation table);

    Task<bool> TryUpdate(
        Guid id,
        Guid tableId,
        Guid customerId,
        DateTimeOffset from,
        DateTimeOffset to,
        string notes,
        ReservationStatus status);

    Task<int> Delete(Guid id);
}