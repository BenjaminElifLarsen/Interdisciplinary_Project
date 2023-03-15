using Shared.Test;

namespace Shared.DDD;
public interface IAggregateRoot<T> : ITestSetId<T>
{
    public T Id { get; }
}

