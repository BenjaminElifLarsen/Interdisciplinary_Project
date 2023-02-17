using Domain.IPL.Repositories.Lifeforms;
using Domain.IPL.Repositories.Messages;
using Domain.IPL.Repositories.Users;
using Shared.UnitOfWork;

namespace Domain.IPL.Services;
public interface IUnitOfWork : IBaseUnitOfWork
{
    public ILifeformRepository LifeformRepository { get; }
    public IAnimalRepository AnimalRepository { get; }
    public IPlantRepository PlantRepository { get; }
    public IUserRepository UserRepository { get; }
    public IMessageRepository MessageRepository { get; }
    public IMessageAuthorRepository MessageAuthorRepository { get; }
    public IMessageLifeformRepository MessageLifeformRepository { get; }
}
