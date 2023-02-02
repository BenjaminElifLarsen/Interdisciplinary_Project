using Domain.DL.Models.LifeformModels;
using Domain.IPL.Repositories.Specifications.Animals;
using Shared.CQRS.Queries;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories;
public sealed class AnimalRepository : IAnimalRepository
{
    private readonly IBaseRepository<Animalia, int> _repository;

    public AnimalRepository(IBaseRepository<Animalia, int> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Animalia, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.AllAsync(query);
    }

    public async Task<Animalia> GetForOperationAsync(int id)
    {
        return await _repository.FindByPredicateForOperationAsync(new ByAnimaliaId(id));
    }

    public async Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Animalia, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.FindByPredicateAsync(new ByAnimaliaId(id), query);
    }

    public async Task<TMapping> GetSingleBySpeciesAsync<TMapping>(string species, BaseQuery<Animalia, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.FindByPredicateAsync(new ByAnimaliaSpecies(species), query);
    }

    public async Task<bool> IsSpeciesInUseAsync(string species)
    {
        return await _repository.IsUniqueAsync(new IsAnimalSpeciesUnique(species));
    }
}
