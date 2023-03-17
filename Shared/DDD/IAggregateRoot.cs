using Shared.Test;

namespace Shared.DDD;
public interface IAggregateRoot<T>
{
    public T Id { get; }
}

