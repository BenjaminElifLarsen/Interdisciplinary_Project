namespace Shared.CQRS.Commands;
public interface ICommandBus
{
    public void RegisterHandler<T>(Action<T> handler) where T : ICommand;
    public void Dispatch<T>(T command) where T : ICommand;
}
