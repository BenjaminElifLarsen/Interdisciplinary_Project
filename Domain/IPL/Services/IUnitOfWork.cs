using Domain.IPL.Repositories;
using Shared.UnitOfWork;

namespace Domain.IPL.Services;
public interface IUnitOfWork : IBaseUnitOfWork
{
    public ILifeformRepository LifeformRepository { get; }
    public IAnimalRepository AnimalRepository { get; }
    public IPlantRepository PlantRepository { get; }
    public IUserRepository UserRepository { get; }
    public IMessageRepository MessageRepository { get; }
}
