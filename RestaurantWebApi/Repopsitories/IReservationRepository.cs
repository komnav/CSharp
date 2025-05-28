using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface IReservationRepository
{
    List<Reservation> GetAll();

    Reservation GetById(Guid id);

    void Create(Reservation table);

    bool TryUpdate(Guid id, Reservation updateTable);

    Reservation Delete(Guid id);
}