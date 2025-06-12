using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public class ReservationRepository(RestaurantContext context) : IReservationRepository
{
    private readonly RestaurantContext _context = context;

    public async Task<List<Reservation>> GetAll()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation> GetById(Guid id)
    {
        return
            await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(Reservation reservation)
    {
        await _context.AddAsync(reservation);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate(
        Guid id,
        Guid tableId,
        Guid customerId,
        DateTimeOffset from,
        DateTimeOffset to,
        string notes,
        ReservationStatus status)
    {
        await _context.Reservations
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(reservation => reservation.TableId, tableId)
                .SetProperty(reservation => reservation.UserId, customerId)
                .SetProperty(reservation => reservation.From, from)
                .SetProperty(reservation => reservation.To, to)
                .SetProperty(reservation => reservation.Notes, notes)
                .SetProperty(reservation => reservation.Status, status));
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> Delete(Guid id)
    {
        return
            await _context.Reservations.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}