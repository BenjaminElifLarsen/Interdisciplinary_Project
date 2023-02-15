using Domain.DL.Models.LifeformModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Plants;
internal class IsPlantSpeciesUnique : ISpecification<Plantae> //could use the base class
{
    private string _species;

    public IsPlantSpeciesUnique(string species)
    {
        _species = species.ToLower();
    }

    public bool IsSatisfiedBy(Plantae candidate)
    {
        return !string.Equals(candidate.Species.ToLower(), _species);
    }
}
