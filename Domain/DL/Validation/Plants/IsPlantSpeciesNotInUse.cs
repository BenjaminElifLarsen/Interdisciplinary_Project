using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Plants;
internal sealed class IsPlantSpeciesNotInUse : ISpecification<RecognisePlant>
{
    private readonly IEnumerable<string> _species;

    public IsPlantSpeciesNotInUse(IEnumerable<string> species)
    {
        _species = species;
    }

    public bool IsSatisfiedBy(RecognisePlant candidate)
    {
        return candidate.Species is not null && !_species.Any(x => string.Equals(x, candidate.Species));
    }
}
