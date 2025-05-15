using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly Dictionary<Guid, TEntity> _entities = [];


    public IEnumerable<TEntity> GetAll()
    {
        return _entities.Values;
    }

    public TEntity GetById(Guid id)
    {
        _entities.TryGetValue(id, out var entity);
        if (entity == null) throw new KeyNotFoundException();
        return entity;
    }

    public void Create(TEntity entity)
    {
        _entities.Add(entity.Id, entity);
    }

    public bool TryUpdate(Guid id, TEntity updateTable)
    {
        if (!_entities.ContainsKey(id))
            return false;
        return true;
    }

    public TEntity Delete(Guid id)
    {
        _entities.TryGetValue(id, out var entity);
        if (entity is not null)
            _entities.Remove(id);
        return (TEntity)entity;
    }
}