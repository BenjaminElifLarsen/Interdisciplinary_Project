using Microsoft.EntityFrameworkCore;
using Shared.CQRS.Queries;
using Shared.DDD;
using Shared.RepositoryPattern;
using Shared.SpecificationPattern;
using System.Linq.Expressions;

namespace SharedImplementation.RepositoryPattern;

public class BaseRepository<TEntity, TId, TContext> : IBaseRepository<TEntity, TId> where TEntity : class, IAggregateRoot<TId> where TContext : DbContext
{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _entities;

    public BaseRepository(TContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel
    {
        return await _entities.Select(query.Map()).ToArrayAsync();
    }

    public async Task<IEnumerable<TMapping>> AllByPredicateAsync<TMapping>(ISpecification<TEntity> predicate, BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel
    {
        var test = (await _entities.ToArrayAsync());
        return test.Where(x => predicate.IsSatisfiedBy(x)).AsQueryable().Select(query.Map()); //if wanting to do the transformation over in the database, would need up modify the predicate to be of TMapping instead of TEntity
    }

        //need to rememember that this project will not use the full ddd, so will need to be able to get relation data objects too
    public async Task<IEnumerable<TEntity>> AllByPredicateForOperationAsync(ISpecification<TEntity> predicate, params Expression<Func<TEntity, object>>[] includes)
    {//need to include first
        var query = _entities.AsQueryable();
        query = includes.Aggregate(query, (source, include) => source.Include(include));
        return (await query.ToArrayAsync()).Where(x => predicate.IsSatisfiedBy(x));
    }

    public void Create(TEntity entity)
    {
        _entities.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
    } 

    public async Task<TMapping> FindByPredicateAsync<TMapping>(ISpecification<TEntity> predicate, BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel
    {
        return (await _entities.ToArrayAsync()).Where(x => predicate.IsSatisfiedBy(x)).AsQueryable().Select(query.Map()).SingleOrDefault();
    }

    public async Task<TEntity> FindByPredicateForOperationAsync(ISpecification<TEntity> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        return (await _entities.ToArrayAsync()).Where(x => predicate.IsSatisfiedBy(x)).SingleOrDefault();
    }

    public async Task<bool> IsUniqueAsync(ISpecification<TEntity> predicate)
    {
        return (await _entities.ToArrayAsync()).Any(x => predicate.IsSatisfiedBy(x));
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }
}
