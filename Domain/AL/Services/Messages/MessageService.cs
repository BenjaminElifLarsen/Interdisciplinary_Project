
using Domain.AL.Busses.Command;

namespace Domain.AL.Services.Messages;
public partial class MessageService : IMessageService
{
    private readonly IDomainCommandBus _commandBus;

	public MessageService(IDomainCommandBus commandBus)
	{
		_commandBus = commandBus;
	}
}
