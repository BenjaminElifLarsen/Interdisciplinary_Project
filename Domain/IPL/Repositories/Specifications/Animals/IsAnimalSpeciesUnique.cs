using Domain.DL.Models.LifeformModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Animals;
internal class IsAnimalSpeciesUnique : ISpecification<Animalia>
{
    private string _species;

    public IsAnimalSpeciesUnique(string species)
    {
        _species = species;
    }

    public bool IsSatisfiedBy(Animalia candidate)
    {
        return !string.Equals(candidate.Species, _species);
    }
}
