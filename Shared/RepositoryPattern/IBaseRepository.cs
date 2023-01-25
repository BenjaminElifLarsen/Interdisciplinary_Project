using Shared.CQRS.Queries;
using Shared.DDD;
using Shared.SpecificationPattern;
using System.Linq.Expressions;

namespace Shared.RepositoryPattern;

public interface IBaseRepository<TEntity, TId> where TEntity : class, IAggregateRoot<TId>
{
    public void Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel;
    public Task<IEnumerable<TMapping>> AllByPredicateAsync<TMapping>(ISpecification<TEntity> predicate, BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel;
    public Task<TMapping> FindByPredicateAsync<TMapping>(ISpecification<TEntity> predicate, BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel;
    public Task<bool> IsUniqueAsync(ISpecification<TEntity> predicate);
    public Task<TEntity> FindByPredicateForOperationAsync(ISpecification<TEntity> predicate, params Expression<Func<TEntity, object>>[] includes);
    public Task<IEnumerable<TEntity>> AllByPredicateForOperationAsync(ISpecification<TEntity> predicate, params Expression<Func<TEntity, object>>[] includes);
    //public Task<IEnumerable<TEntity>> AllByPredicateForOperationAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
} //consider if this pattern can be combined with the specification pattern used for data validation
  //even when using composite specifications the type is still ISpecification<T> 
  //so ISpecification<TEntity> predicate and params ISpecification<TEntity>[] predicates
  //so specifcication used for data validation in factory and for repo. pattern, neat
  //however, this might require moving the sql queries from the sql database to the backend. Explain this in the report and display a line of code of the two versions