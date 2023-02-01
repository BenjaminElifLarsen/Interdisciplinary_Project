using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;

namespace Domain.IPL.Repositories;
public interface IPlantRepository
{
    public Task<bool> IsSpeciesInUseAsync(string species);
    public Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Plantae, TMapping> query) where TMapping : BaseReadModel;
    public Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Plantae, TMapping> query) where TMapping : BaseReadModel;
    public Task<Plantae> GetForOperationAsync(int id);
    public Task<TMapping> GetSingleBySpeciesAsync<TMapping>(string species, BaseQuery<Plantae, TMapping> query) where TMapping : BaseReadModel;
}
