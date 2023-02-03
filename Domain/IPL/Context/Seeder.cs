using Domain.AL.Busses.Command;
using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Validation.ReadModels;
using Domain.IPL.Services;
using Shared.Routing;

namespace Domain.IPL.Context;
public static class Seeder
{
    public static void MockSeedData(IDomainCommandBus commandBus, IRoutingRegistry routingRegistry, IUnitOfWork unitOfWork)
    {
        routingRegistry.SetUpRouting();

        var plantSpecies = unitOfWork.PlantRepository.AllAsync(new PlantIdQuery()).Result;
        var animalSpecies = unitOfWork.AnimalRepository.AllAsync(new AnimalIdQuery()).Result;
        var users = unitOfWork.UserRepository.AllAsync(new UserIdQuery()).Result;

        if(!users.Any())
        {
            commandBus.Dispatch(new RegistrateUser("Triss", "Larsen", "Test123!", "Tester1"));
            commandBus.Dispatch(new RegistrateUser("Bente", "Larsen", "Test123!", "Tester2"));
        }
        if(!plantSpecies.Any())
        {
            commandBus.Dispatch(new RecognisePlant(5, "Soldug"));
        }
        if (!animalSpecies.Any())
        {
            commandBus.Dispatch(new RecogniseAnimal(5, 3, true, "Husskade"));
            commandBus.Dispatch(new RecogniseAnimal(2, 2, false, "Rådyr"));
        }
    }
}
