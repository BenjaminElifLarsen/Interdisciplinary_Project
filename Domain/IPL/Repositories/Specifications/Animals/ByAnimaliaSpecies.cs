using Domain.DL.Models.LifeformModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Animals;
internal class ByAnimaliaSpecies : ISpecification<Animalia>
{
    private readonly string _species;

    public ByAnimaliaSpecies(string species)
    {
        _species = species;
    }

    public bool IsSatisfiedBy(Animalia candidate)
    {
        return string.Equals(candidate.Species, _species);
    }
}
