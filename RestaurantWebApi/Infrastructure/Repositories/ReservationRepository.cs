using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Repositories;

public class ReservationRepository(RestaurantContext context) : IReservationRepository
{
    private readonly RestaurantContext _context = context;

    public List<Reservation> GetAll()
    {
        return _context.Reservations.ToList();
    }

    public Reservation GetById(Guid id)
    {
        return _context.Reservations.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Reservation reservation)
    {
        _context.Add(reservation);
        _context.SaveChanges();
    }

    public bool TryUpdate(Guid id, Reservation updateReservation)
    {
        _context.Reservations
            .Where(x => x.Id == id)
            .ExecuteUpdate(x => x
                .SetProperty(reservation => reservation.TableId, updateReservation.TableId)
                .SetProperty(reservation => reservation.From, updateReservation.From)
                .SetProperty(reservation => reservation.To, updateReservation.To)
                .SetProperty(reservation => reservation.Notes, updateReservation.Notes)
                .SetProperty(reservation => reservation.Status, updateReservation.Status));
        return _context.SaveChanges() > 0;
    }

    public Reservation Delete(Guid id)
    {
        var reservation = GetById(id);
        _context.Reservations.Where(x => x.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return reservation;
    }
}