using Domain.DL.Models.LifeformModels;
using Domain.IPL.Repositories.Specifications.Plants;
using Shared.CQRS.Queries;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories;
internal class PlantRepository : IPlantRepository
{
    private readonly IBaseRepository<Plantae, int> _repository;

    public PlantRepository(IBaseRepository<Plantae, int> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Plantae, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.AllAsync(query);
    }

    public async Task<Plantae> GetForOperationAsync(int id)
    {
        return await _repository.FindByPredicateForOperationAsync(new ByPlantId(id));
    }

    public async Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Plantae, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.FindByPredicateAsync(new ByPlantId(id), query);
    }

    public async Task<TMapping> GetSingleBySpeciesAsync<TMapping>(string species, BaseQuery<Plantae, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.FindByPredicateAsync(new ByPlantSpecies(species), query);
    }

    public async Task<bool> IsSpeciesInUseAsync(string species)
    {
        return await _repository.IsUniqueAsync(new IsPlantSpeciesUnique(species));
    }
}
