using Domain.AL.Services.Lifeforms.Queries.GetAllAnimals;
using Domain.AL.Services.Lifeforms.Queries.GetAllPlants;
using Domain.AL.Services.Lifeforms.Queries.GetSingleAnimal;
using Domain.AL.Services.Lifeforms.Queries.GetSinglePlant;
using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Lifeforms;
public interface ILifeformService
{
    public Task<Result> RecogniseAnimal(RecogniseAnimal command);
    public Task<Result> RecognisePlant(RecognisePlant command);

    public Task<Result<IEnumerable<PlantListItem>>> GetAllPlants();
    public Task<Result<IEnumerable<AnimalListItem>>> GetAllAnimals();
    public Task<Result<PlantDetails>> GetPlant(int id);
    public Task<Result<AnimalDetails>> GetAnimal(int id);
}
