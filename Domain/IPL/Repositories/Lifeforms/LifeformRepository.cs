using Domain.DL.Models.LifeformModels;
using Domain.IPL.Repositories.Specifications.Animals;
using Domain.IPL.Repositories.Specifications.Plants;
using Shared.CQRS.Queries;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories.Lifeforms;
public class LifeformRepository : ILifeformRepository
{
    private readonly IBaseRepository<Animalia, int> _animalRepository;
    private readonly IBaseRepository<Plantae, int> _plantRepository;

    public LifeformRepository(IBaseRepository<Animalia, int> animalRepository, IBaseRepository<Plantae, int> plantRepository)
    {
        _animalRepository = animalRepository;
        _plantRepository = plantRepository;
    }

    public void AddLifeform(Eukaryote entity)
    {
        if (entity is Animalia)
        {
            _animalRepository.Create(entity as Animalia);
        }
        else if (entity is Plantae)
        {
            _plantRepository.Create(entity as Plantae);
        }
    }

    public async Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Eukaryote, TMapping> query) where TMapping : BaseReadModel
    {
        List<Eukaryote> list = new();
        list.AddRange(await _animalRepository.AllForOperationAsync());
        list.AddRange(await _plantRepository.AllForOperationAsync());
        return list.AsQueryable().Select(query.Map());
    }

    public async Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Eukaryote, TMapping> query) where TMapping : BaseReadModel
    {
        Eukaryote entity = null;
        entity = await _animalRepository.FindByPredicateForOperationAsync(new ByAnimaliaId(id));
        if(entity is null)
        {
            entity = await _plantRepository.FindByPredicateForOperationAsync(new ByPlantId(id));
        }
        if( entity is null)
        {
            return null;
        }
        return new List<Eukaryote>() { entity }.AsQueryable().Select(query.Map()).Single();
    }

    public void RemoveLifeform(Eukaryote entity)
    {
        if (entity is Animalia)
        {
            _animalRepository.Delete(entity as Animalia);
        }
        else if (entity is Plantae)
        {
            _plantRepository.Delete(entity as Plantae);
        }
    }

    public void UpdateLifeform(Eukaryote entity)
    {
        if (entity is Animalia)
        {
            _animalRepository.Update(entity as Animalia);
        }
        else if (entity is Plantae)
        {
            _plantRepository.Update(entity as Plantae);
        }
    }
}
