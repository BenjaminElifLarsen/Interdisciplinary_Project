using Domain.DL.Models.LifeformModels;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories;
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
        if(entity is Animalia)
        {
            _animalRepository.Create(entity as Animalia);
        }
        else if (entity is Plantae) 
        {
            _plantRepository.Create(entity as Plantae);
        }
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
