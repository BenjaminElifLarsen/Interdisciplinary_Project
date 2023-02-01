using Domain.DL.Models.LifeformModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Plants;
internal class ByPlantId : ISpecification<Plantae>
{
    private readonly int _id;

    public ByPlantId(int id)
    {
        _id = id;
    }

    public bool IsSatisfiedBy(Plantae candidate)
    {
        return candidate.Id == _id;
    }
}
