using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;

namespace Domain.IPL.Repositories.Lifeforms;
/// <summary>
/// Used to add, remove, and update animals and plants
/// </summary>
public interface ILifeformRepository
{
    public void AddLifeform(Eukaryote entity);
    public void RemoveLifeform(Eukaryote entity);
    public void UpdateLifeform(Eukaryote entity);
    public Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Eukaryote, TMapping> query) where TMapping : BaseReadModel;
    public Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Eukaryote, TMapping> query) where TMapping : BaseReadModel;
}
