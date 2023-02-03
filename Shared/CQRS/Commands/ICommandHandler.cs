using Shared.ResultPattern.Abstract;

namespace Shared.CQRS.Commands;
public interface ICommandHandler<T> where T : ICommand
{
    Result Handle(T command);
}
