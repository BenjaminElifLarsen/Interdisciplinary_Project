using Shared.CQRS.Commands;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Busses.Command;
public class DomainCommandBus : IDomainCommandBus
{
    private readonly Dictionary<Type, List<Func<ICommand,Result>>> _routes;

    public DomainCommandBus()
    {
        _routes = new();
    }

    public Result Dispatch<T>(T command) where T : ICommand
    {
        if (!_routes.TryGetValue(command.GetType(), out List<Func<ICommand,Result>> handlers))
            return null;
        if (handlers.Count > 1)
            throw new Exception("To many command handlers.");
        return handlers[0](command);
    }

    public void RegisterHandler<T>(Func<T,Result> handler) where T : ICommand
    {
        List<Func<ICommand, Result>> handlers;

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
