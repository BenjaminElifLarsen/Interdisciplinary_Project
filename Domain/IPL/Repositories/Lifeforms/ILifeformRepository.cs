using Domain.DL.Models.LifeformModels;

namespace Domain.IPL.Repositories.Lifeforms;
/// <summary>
/// Used to add, remove, and update animals and plants
/// </summary>
public interface ILifeformRepository
{
    public void AddLifeform(Eukaryote entity);
    public void RemoveLifeform(Eukaryote entity);
    public void UpdateLifeform(Eukaryote entity);
}
