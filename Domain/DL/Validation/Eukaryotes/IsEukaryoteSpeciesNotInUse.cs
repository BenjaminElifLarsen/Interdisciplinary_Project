using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Eukaryotes;
internal class IsEukaryoteSpeciesNotInUse : ISpecification<ChangeLifeformInformation>
{
	public IEnumerable<LifeformSpecies> _species;
	public IsEukaryoteSpeciesNotInUse(IEnumerable<LifeformSpecies> species)
	{
		_species = species;
	}

    public bool IsSatisfiedBy(ChangeLifeformInformation candidate)
    {
		return candidate.Species is null || (!string.IsNullOrWhiteSpace(candidate.Species.Species) && !_species.Any(x => Equals(x.Species, candidate.Species.Species)));
    }
}
