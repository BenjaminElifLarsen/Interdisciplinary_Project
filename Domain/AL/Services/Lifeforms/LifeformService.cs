using Domain.AL.Busses.Command;
using Domain.DL.Factories;
using Domain.IPL.Services;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService : ILifeformService
{
	private readonly IDomainCommandBus _commandBus;
	private readonly IUnitOfWork _unitOfWork;

	public LifeformService(IUnitOfWork unitOfWork, IDomainCommandBus commandBus)
	{
		_unitOfWork = unitOfWork;
		_commandBus = commandBus;
	}

}
