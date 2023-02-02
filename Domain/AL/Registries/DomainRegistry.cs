using Domain.AL.Busses.Command;
using Domain.AL.Handlers.Commands;
using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.CQRS.Commands.Users;
using Shared.Routing;

namespace Domain.AL.Registries;
public class DomainRegistry : IRoutingRegistry
{
    private readonly IDomainCommandBus _commandBus;
    private readonly IDomainCommandHandler _commandHandler;

    public DomainRegistry(IDomainCommandBus commandBus, IDomainCommandHandler commandHandler)
    {
        _commandBus = commandBus;
        _commandHandler = commandHandler;
    }

    public void SetUpRouting()
    {
        _commandBus.RegisterHandler<PostMessage>(_commandHandler.Handle);
        _commandBus.RegisterHandler<RecogniseLifeform>(_commandHandler.Handle);
        _commandBus.RegisterHandler<LikeMessage>(_commandHandler.Handle);
        _commandBus.RegisterHandler<RegistrateUser>(_commandHandler.Handle);
    }
}
