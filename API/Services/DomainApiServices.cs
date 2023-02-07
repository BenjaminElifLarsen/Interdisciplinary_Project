using Domain.AL.Busses.Command;
using Domain.AL.Handlers.Commands;
using Domain.AL.Registries;
using Domain.AL.Services.Lifeforms;
using Domain.AL.Services.Messages;
using Domain.DL.Factories;
using Domain.DL.Models.LifeformModels;
using Domain.DL.Models.MessageModels;
using Domain.DL.Models.UserModels;
using Domain.IPL.Context;
using Domain.IPL.Repositories;
using Domain.IPL.Services;
using Microsoft.EntityFrameworkCore;
using Shared.RepositoryPattern;
using Shared.Routing;
using SharedImplementation.RepositoryPattern;
namespace API.Services;

public class DomainApiServices
{
    public static void Add(IServiceCollection services, string dbConnection)
    {
        Context(services, dbConnection);
        UnitOfWork(services);
        Factories(services);
        Repositories(services);
        Handlers(services);
        Services(services);
    }

    private static void Services(IServiceCollection services)
    {
        services.AddScoped<ILifeformService, LifeformService>();
        services.AddScoped<IMessageService, MessageService>();
    }

    private static void Context(IServiceCollection services, string dbConnection)
    {
        services.AddDbContext<LifeformContext>(options => options.UseSqlServer(dbConnection));
        services.AddDbContext<MessageContext>(options => options.UseSqlServer(dbConnection));
        services.AddDbContext<UserContext>(options => options.UseSqlServer(dbConnection));
    }
    private static void UnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void Factories(IServiceCollection services)
    {
        services.AddScoped<IUserFactory, UserFactory>();
        services.AddScoped<IMessageFactory, MessageFactory>();
        services.AddScoped<ILifeformFactory, LifeformFactory>();
    }

    private static void Repositories(IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<Eukaryote, int>, BaseRepository<Eukaryote, int, LifeformContext>>();
        services.AddScoped<IBaseRepository<User, int>, BaseRepository<User, int, UserContext>>();
        services.AddScoped<IBaseRepository<Message, int>, BaseRepository<Message, int, MessageContext>>();
        services.AddScoped<IBaseRepository<Animalia, int>, BaseRepository<Animalia, int, LifeformContext>>();
        services.AddScoped<IBaseRepository<Plantae, int>, BaseRepository<Plantae, int, LifeformContext>>();

        services.AddScoped<ILifeformRepository, LifeformRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddScoped<IPlantRepository, PlantRepository>();
    }

    private static void Handlers(IServiceCollection services)
    {
        services.AddScoped<IDomainCommandHandler, DomainCommandHandler>();
        services.AddScoped<IDomainCommandBus, DomainCommandBus>();
        services.AddScoped<IRoutingRegistry, DomainRegistry>();
    }

    public static void Seed(IServiceProvider provider)
    {
        var serviceProvider = provider.CreateScope().ServiceProvider;

        Seeder.MockSeedData(serviceProvider.GetService<IDomainCommandBus>(),
            serviceProvider.GetService<IRoutingRegistry>(),
            serviceProvider.GetService<IUnitOfWork>());
    }

}
