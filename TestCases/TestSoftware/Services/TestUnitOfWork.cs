using Domain.DL.Models.LifeformModels;
using Domain.DL.Models.MessageModels;
using Domain.DL.Models.UserModels;
using Domain.IPL.Repositories.Lifeforms;
using Domain.IPL.Repositories.Messages;
using Domain.IPL.Repositories.Users;
using Domain.IPL.Services;
using TestCases.TestSoftware.Context;
using TestCases.TestSoftware.Repository;

namespace TestCases.TestSoftware.Services;
internal class TestUnitOfWork<TContext> : IUnitOfWork where TContext : ITestContext
{
    private readonly TContext _context;

    public TestUnitOfWork(TContext context)
    {
        _context = context;
        LifeformRepository = new LifeformRepository(new TestRepository<Animalia>(context), new TestRepository<Plantae>(context));
        AnimalRepository = new AnimalRepository(new TestRepository<Animalia>(context));
        PlantRepository = new PlantRepository(new TestRepository<Plantae>(context));
        UserRepository = new UserRepository(new TestRepository<User>(context));
        MessageRepository = new MessageRepository(new TestRepository<Message>(context));
        MessageAuthorRepository = new MessageAuthorRepository(new TestRepository<Author>(context));
        MessageLifeformRepository = new MessageLifeformRepository(new TestRepository<Lifeform>(context));
    }

    public ILifeformRepository LifeformRepository { get; }

    public IAnimalRepository AnimalRepository { get; }

    public IPlantRepository PlantRepository { get; }

    public IUserRepository UserRepository { get; }

    public IMessageRepository MessageRepository { get; }

    public IMessageAuthorRepository MessageAuthorRepository { get; }

    public IMessageLifeformRepository MessageLifeformRepository { get; }

    public void Save()
    {
        _context.Save();
    }
}
