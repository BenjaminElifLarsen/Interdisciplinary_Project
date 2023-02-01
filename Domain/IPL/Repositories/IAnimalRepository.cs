using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;

namespace Domain.IPL.Repositories;
public interface IAnimalRepository //no add, remove, and update here
{
    public Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Animalia, TMapping> query) where TMapping : BaseReadModel;
    public Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Animalia, TMapping> query) where TMapping : BaseReadModel;
    public Task<Animalia> GetForOperationAsync(int id);
    public Task<TMapping> GetSingleBySpeciesAsync<TMapping>(string species, BaseQuery<Animalia, TMapping> query) where TMapping : BaseReadModel;
    public Task<bool> IsSpeciesInUseAsync(string species);
}
