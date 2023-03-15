using Shared.CQRS.Queries;
using Shared.DDD;
using Shared.RepositoryPattern;
using Shared.SpecificationPattern;
using System.Linq.Expressions;
using TestCases.TestSoftware.Context;

namespace TestCases.TestSoftware.Repository;
internal class TestRepository<TEntity> : IBaseRepository<TEntity, int> where TEntity : class, IAggregateRoot<int>
{
    private readonly ITestContext _context;
    private readonly IEnumerable<TEntity> _data;
    private int _idNumber;

    public TestRepository(ITestContext context)
    {
        _context = context;
        _data = _context.Set<TEntity>();
        _idNumber = 0;
    }

    public async Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel
    {
        return await Task.Run<IEnumerable<TMapping>>(() => _data.AsQueryable().Select(query.Map()).ToArray());
    }

    public async Task<IEnumerable<TMapping>> AllByPredicateAsync<TMapping>(ISpecification<TEntity> predicate, BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel
    {
        return await Task.Run<IEnumerable<TMapping>>(() => _data.AsQueryable().Where(x => predicate.IsSatisfiedBy(x)).Select(query.Map()).ToArray());
    }

    public async Task<IEnumerable<TEntity>> AllByPredicateForOperationAsync(ISpecification<TEntity> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        return await Task.Run<IEnumerable<TEntity>>(() => _data.AsQueryable().Where(x => predicate.IsSatisfiedBy(x)).ToArray());
    }

    public async Task<IEnumerable<TEntity>> AllForOperationAsync()
    {
        return await Task.Run(() => _data);
    }

    public void Create(TEntity entity)
    {
        entity.SetTestId(++_idNumber);
        _context.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Remove(entity);
    }

    public async Task<TMapping> FindByPredicateAsync<TMapping>(ISpecification<TEntity> predicate, BaseQuery<TEntity, TMapping> query) where TMapping : BaseReadModel
    {
        return await Task.Run<TMapping>(() => _data.AsQueryable().Where(x => predicate.IsSatisfiedBy(x)).Select(query.Map()).SingleOrDefault());
    }

    public async Task<TEntity> FindByPredicateForOperationAsync(ISpecification<TEntity> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        return await Task.Run<TEntity>(() => _data.AsQueryable().Where(x => predicate.IsSatisfiedBy(x)).SingleOrDefault());
    }

    public async Task<bool> IsUniqueAsync(ISpecification<TEntity> predicate)
    {
        return await Task.Run(() => !_data.AsQueryable().Any(x => predicate.IsSatisfiedBy(x)));
    }

    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }
}
