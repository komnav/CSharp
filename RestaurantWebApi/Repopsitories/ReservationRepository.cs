using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly Dictionary<Guid, Reservation> _reservations = [];

    public IEnumerable<Reservation> GetAll()
    {
        return _reservations.Values;
    }

    public Reservation GetById(Guid id)
    {
        _reservations.TryGetValue(id, out var entity);
        return entity;
    }

    public void Create(Reservation table)
    {
        _reservations.Add(table.Id, table);
    }

    public bool TryUpdate(Guid id, Reservation updateTable)
    {
        if (!_reservations.ContainsKey(id)) return false;

        _reservations[id] = updateTable;
        return true;
    }

    public Reservation Delete(Guid id)
    {
        _reservations.TryGetValue(id, out var reservation);
        if (reservation is not null)
        {
            _reservations.Remove(id);
        }

        return reservation;
    }
}