using Domain.AL.Busses.Command;
using Domain.AL.Handlers.Commands;
using Domain.AL.Registries;
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
    }

    private static void Context(IServiceCollection services, string dbConnection)
    {
        services.AddDbContext<DomainContext>(options => options.UseSqlServer(dbConnection));
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
        services.AddScoped<IBaseRepository<Eukaryote, int>, BaseRepository<Eukaryote, int, DomainContext>>();
        services.AddScoped<IBaseRepository<User, int>, BaseRepository<User, int, DomainContext>>();
        services.AddScoped<IBaseRepository<Message, int>, BaseRepository<Message, int, DomainContext>>();
        services.AddScoped<IBaseRepository<Animalia, int>, BaseRepository<Animalia, int, DomainContext>>();
        services.AddScoped<IBaseRepository<Plantae, int>, BaseRepository<Plantae, int, DomainContext>>();

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
        throw new NotImplementedException();
    }

}
