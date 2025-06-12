using Microsoft.Extensions.Caching.Memory;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;

namespace RestaurantWeb.Infrastructure.Repositories;

public class CachedMemberRepository(ReservationRepository decorated, IMemoryCache cache) : IReservationRepository
{
    private readonly IMemoryCache _cache = cache;
    private readonly ReservationRepository _decorated = decorated;

    public Task<List<Reservation>> GetAll()
    {
        string key = $"Reservation";
        return _cache.GetOrCreate(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetAll();
            });
    }

    public Task<Reservation> GetById(Guid id)
    {
        string key = $"Reservation-{id}";
        return _cache.GetOrCreate(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetById(id);
            });
    }

    public Task<int> Create(Reservation table) => _decorated.Create(table);

    public Task<bool> TryUpdate(
        Guid id,
        Guid tableId,
        Guid customerId,
        DateTimeOffset from,
        DateTimeOffset to,
        string notes,
        ReservationStatus status) => _decorated.TryUpdate(id, tableId, customerId, from, to, notes, status);

    public Task<int> Delete(Guid id) => _decorated.Delete(id);
}