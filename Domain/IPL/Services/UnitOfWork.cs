using Domain.IPL.Context;
using Domain.IPL.Repositories;
using SharedImplementation.Services;

namespace Domain.IPL.Services;
public sealed class UnitOfWork : EntityFrameworkUnitOfWork<DomainContext>, IUnitOfWork
{
    private readonly ILifeformRepository _lifeformRepository;
    private readonly IAnimalRepository _animalRepository;
    private readonly IPlantRepository _plantRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;

    public ILifeformRepository LifeformRepository => _lifeformRepository;
    public IAnimalRepository AnimalRepository => _animalRepository;
    public IPlantRepository PlantRepository => _plantRepository;
    public IUserRepository UserRepository => _userRepository;
    public IMessageRepository MessageRepository => _messageRepository;

    public UnitOfWork(DomainContext context, ILifeformRepository lifeformRepository, IAnimalRepository animalRepository,
        IPlantRepository plantRepository, IUserRepository userRepository, IMessageRepository messageRepository) : base(context)
    {
        _lifeformRepository = lifeformRepository;
        _animalRepository = animalRepository;
        _plantRepository = plantRepository;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
    }
}
