using RestaurantWeb.Model;

namespace RestaurantWeb.Repositories;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    IEnumerable<TEntity> GetAll();
    TEntity GetById(Guid id);

    void Create(TEntity table);

    bool TryUpdate(Guid id, TEntity updateTable);

    TEntity? Delete(Guid id);
}