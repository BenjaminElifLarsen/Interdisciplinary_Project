using Shared.CQRS.Queries;
using Shared.DDD;

namespace Shared.RepositoryPattern;

public interface IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
{
    public void Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public Task<IEnumerable<TProjection>> AllAsync<TProjection>(BaseQuery<TEntity, TProjection> query) where TProjection : BaseReadModel;
    public Task<IEnumerable<TProjection>> AllByPredicateAsync<TProjection>(Expression<Func<TEntity, bool>> predicate, BaseQuery<TEntity, TProjection> query) where TProjection : BaseReadModel;
    public Task<TProjection> FindByPredicateAsync<TProjection>(Expression<Func<TEntity, bool>> predicate, BaseQuery<TEntity, TProjection> query) where TProjection : BaseReadModel;
    public Task<bool> IsUniqueAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<TEntity> FindByPredicateForOperationAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    public Task<IEnumerable<TEntity>> AllByPredicateForOperationAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
} //consider if this pattern can be combined with the specification pattern used for data validation
  //https://dotnetfalcon.com/using-the-specification-pattern-with-repository-and-unit-of-work/