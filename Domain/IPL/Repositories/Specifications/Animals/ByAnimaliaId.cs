using Domain.DL.Models.LifeformModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Animals;
internal sealed class ByAnimaliaId : ISpecification<Animalia>
{
    private readonly int _id;
    public ByAnimaliaId(int id)
    {
        _id = id;
    }

    public bool IsSatisfiedBy(Animalia candidate)
    {
        return candidate.Id == _id;
    }
}
