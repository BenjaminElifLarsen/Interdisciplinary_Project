using Shared.CQRS.Commands;

namespace Domain.AL.Busses.Command;
public class DomainCommandBus : IDomainCommandBus
{
    private readonly Dictionary<Type, List<Action<ICommand>>> _routes;

    public DomainCommandBus()
    {
        _routes = new();
    }

    public void Dispatch<T>(T command) where T : ICommand
    {
        if (!_routes.TryGetValue(command.GetType(), out List<Action<ICommand>> handlers))
            return;
        if (handlers.Count > 1)
            throw new Exception("To many command handlers.");
        handlers[0](command);
        return;
    }

    public void RegisterHandler<T>(Action<T> handler) where T : ICommand
    {
        List<Action<ICommand>> handlers;

        if (!_routes.TryGetValue(typeof(T), out handlers))
        {
            handlers = new();
            _routes.Add(typeof(T), handlers);
        }

        if (handlers.Any())
            throw new Exception("Cannot add more handlers. Commands can only have a single handler.");

        handlers.Add(x => handler((T)x));
    }
}
