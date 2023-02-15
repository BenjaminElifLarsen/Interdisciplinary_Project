using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Plants;
internal sealed class IsPlantSpeciesNotInUse : ISpecification<RecognisePlant>
{
    private readonly IEnumerable<LifeformSpecies> _species;

    public IsPlantSpeciesNotInUse(IEnumerable<LifeformSpecies> species)
    {
        _species = species;
    }

    public bool IsSatisfiedBy(RecognisePlant candidate)
    {
        return candidate.Species is not null && !_species.Any(x => string.Equals(x.Species.ToLower(), candidate.Species.ToLower()));
    }
}
