using Domain.DL.Factories;
using Domain.IPL.Services;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService : ILifeformService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILifeformFactory _lifeformFactory;

	public LifeformService(IUnitOfWork unitOfWork, ILifeformFactory lifeformFactory)
	{
		_unitOfWork = unitOfWork;
		_lifeformFactory = lifeformFactory;
	}

}
