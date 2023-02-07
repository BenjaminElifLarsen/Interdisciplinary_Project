
using Domain.AL.Busses.Command;
using Domain.IPL.Services;

namespace Domain.AL.Services.Messages;
public partial class MessageService : IMessageService
{
    private readonly IDomainCommandBus _commandBus;
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IDomainCommandBus commandBus, IUnitOfWork unitOfWork)
	{
		_commandBus = commandBus;
        _unitOfWork = unitOfWork;
	}
}
