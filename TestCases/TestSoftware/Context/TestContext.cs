using Shared.DDD;

namespace TestCases.TestSoftware.Context;
internal class TestContext : ITestContext
{
    private readonly HashSet<EntityState<object>> _data;

    public TestContext()
    {
        _data = new();
    }

    public void Add(IAggregateRoot<int> root)
    {
        if (!_data.Any(x => x.Entity == root))
            _data.Add(new(root, State.Add));
    }

    public void Remove(IAggregateRoot<int> root)
    {
        var entity = _data.SingleOrDefault(x => x.Entity == root);
        if (entity is not null)
        {
            entity.State = State.Remove;
        }
    }

    public int Save()
    {
        int amount = _data.Count(x => x.State != State.Tracked);
        Update();
        Add();
        Remove();
        return amount;
    }

    public IEnumerable<T> Set<T>()
    {
        return _data.Where(x => x.Entity is T).Select(x => (T)x.Entity);
    }

    public void Update(IAggregateRoot<int> root)
    {
        var entity = _data.SingleOrDefault(x => x.Entity == root);
        if (entity is not null)
        {
            entity.State = State.Update;
        }
    }

    private void Add()
    {
        var entitesToAdd = _data.Where(x => x.State == State.Add).ToArray();
        for (int i = 0; i < entitesToAdd.Length; i++)
        {
            entitesToAdd[i].State = State.Tracked;
        }
    }

    private void Remove()
    {
        var entitiesToRemove = _data.Where(x => x.State == State.Remove).ToArray();
        for (int i = 0; i < entitiesToRemove.Length; i++)
        {
            entitiesToRemove[i].State = State.Tracked;
            _data.Remove(entitiesToRemove[i]);
        }
    }

    private void Update()
    {
        var entitiesToUpdate = _data.Where(x => x.State == State.Update).ToArray();
        for (int i = 0; i < entitiesToUpdate.Length; i++)
        {
            entitiesToUpdate[i].State = State.Tracked;
        }
    }

    enum State
    {
        Add = 1,
        Update = 2,
        Remove = 3,
        Tracked = 4,

        Unknown = 0
    }

    record EntityState<T>
    {
        public State State { get; set; }
        public T Entity { get; set; }

        public EntityState(T entity, State state)
        {
            Entity = entity;
            State = state;
        }

        public override int GetHashCode()
        {
            return Entity is not null ? Entity.GetHashCode() : base.GetHashCode();
        }
    }
}
