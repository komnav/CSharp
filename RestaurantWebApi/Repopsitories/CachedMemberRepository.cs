using Microsoft.Extensions.Caching.Memory;
using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class CachedMemberRepository(ReservationRepository decorated, IMemoryCache cache) : IReservationRepository
{
    private readonly IMemoryCache _cache = cache;
    private readonly ReservationRepository _decorated = decorated;

    public List<Reservation> GetAll()
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

    public Reservation GetById(Guid id)
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

    public void Create(Reservation table) => _decorated.Create(table);
    public bool TryUpdate(Guid id, Reservation updateTable) => _decorated.TryUpdate(id, updateTable);

    public Reservation Delete(Guid id) => _decorated.Delete(id);
}