using Shared.DDD;

namespace TestCases.TestSoftware.Context;
internal interface ITestContext
{
    public int Save();
    public void Add(IAggregateRoot<int> root);
    public void Update(IAggregateRoot<int> root);
    public void Remove(IAggregateRoot<int> root);
    public IEnumerable<T> Set<T>();
}
