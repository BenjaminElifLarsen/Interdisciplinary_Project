using Shared.ResultPattern.Abstract;

namespace Shared.CQRS.Commands;
public interface ICommandBus
{
    public void RegisterHandler<T>(Func<T,Result> handler) where T : ICommand;
    public Result Dispatch<T>(T command) where T : ICommand;
}
