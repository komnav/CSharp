using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly Dictionary<Guid, IEntity> _entities = [];

    IEnumerable<TEntity> IRepository<TEntity>.GetAll()
    {
        throw new NotImplementedException();
    }

    public TEntity GetById(Guid id)
    {
        _entities.TryGetValue(id, out var entity);
        return (TEntity)entity;
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