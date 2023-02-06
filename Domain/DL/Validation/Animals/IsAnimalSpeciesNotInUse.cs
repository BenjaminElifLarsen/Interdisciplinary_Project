using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Models.LifeformModels;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Animals;
//named the way it is as I like to have the true return mean the object is valid. 
internal sealed class IsAnimalSpeciesNotInUse : ISpecification<RecogniseAnimal>
{
    private readonly IEnumerable<LifeformSpecies> _species;

	public IsAnimalSpeciesNotInUse(IEnumerable<LifeformSpecies> species)
	{
		_species = species;
	}



    public bool IsSatisfiedBy(RecogniseAnimal candidate)
    {
        return candidate.Species is not null && !_species.Any(x => string.Equals(x.Species, candidate.Species));
    }
}
