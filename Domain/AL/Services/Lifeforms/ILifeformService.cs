using Domain.AL.Services.Lifeforms.Queries.GetAllAnimals;
using Domain.AL.Services.Lifeforms.Queries.GetAllPlants;
using Domain.AL.Services.Lifeforms.Queries.GetSingleAnimal;
using Domain.AL.Services.Lifeforms.Queries.GetSinglePlant;
using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Lifeforms;
public interface ILifeformService
{
    public Task<Result> RecogniseAnimalAsync(RecogniseAnimal command);
    public Task<Result> RecognisePlantAsync(RecognisePlant command);
    public Task<Result> UnrecogniseAsync(UnreogniseLifeform command);
    public Task<Result> UpdateAnimalAsync(ChangeAnimalInformation command);
    public Task<Result> UpdatePlantAsync(ChangePlantInformation command);

    public Task<Result<IEnumerable<PlantListItem>>> AllPlantsAsync();
    public Task<Result<IEnumerable<AnimalListItem>>> AllAnimalsAsync();
    public Task<Result<PlantDetails>> GetPlantAsync(int id);
    public Task<Result<AnimalDetails>> GetAnimalAsync(int id);
}
