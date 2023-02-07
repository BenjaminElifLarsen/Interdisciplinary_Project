using Domain.IPL.Context;
using Domain.IPL.Repositories;
using SharedImplementation.Services;

namespace Domain.IPL.Services;
public sealed class UnitOfWork : /*EntityFrameworkUnitOfWork<LifeformContext>,*/ IUnitOfWork
{
    private readonly ILifeformRepository _lifeformRepository;
    private readonly IAnimalRepository _animalRepository;
    private readonly IPlantRepository _plantRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;

    private readonly LifeformContext _lifeformContext;
    private readonly UserContext _userContext;
    private readonly MessageContext _messageContext;

    public ILifeformRepository LifeformRepository => _lifeformRepository;
    public IAnimalRepository AnimalRepository => _animalRepository;
    public IPlantRepository PlantRepository => _plantRepository;
    public IUserRepository UserRepository => _userRepository;
    public IMessageRepository MessageRepository => _messageRepository;

    public UnitOfWork(LifeformContext lifeformContext, UserContext userContext, MessageContext messageContext, ILifeformRepository lifeformRepository, IAnimalRepository animalRepository,
        IPlantRepository plantRepository, IUserRepository userRepository, IMessageRepository messageRepository)
    {
        _lifeformRepository = lifeformRepository;
        _animalRepository = animalRepository;
        _plantRepository = plantRepository;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
        _lifeformContext = lifeformContext;
        _userContext = userContext;
        _messageContext = messageContext;
    }

    public void Save()
    {
        _lifeformContext.SaveChanges();
        _userContext.SaveChanges();
        _messageContext.SaveChanges();
    }
}
