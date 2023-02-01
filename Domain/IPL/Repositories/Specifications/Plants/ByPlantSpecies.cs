using Domain.DL.Models.LifeformModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Plants;
internal class ByPlantSpecies : ISpecification<Plantae>
{
    private readonly string _species;

    public ByPlantSpecies(string species)
    {
        _species = species;
    }

    public bool IsSatisfiedBy(Plantae candidate)
    {
        return string.Equals(candidate.Species, _species);
    }
}
