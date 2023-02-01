using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Models.LifeformModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Animals;
//named the way it is as I like to have the true return mean the object is valid. 
internal sealed class IsAnimalSpeciesNotInUse : ISpecification<RecogniseAnimal>
{
    private readonly IEnumerable<string> _species;

	public IsAnimalSpeciesNotInUse(IEnumerable<string> species)
	{
		_species = species;
	}



    public bool IsSatisfiedBy(RecogniseAnimal candidate)
    {
        return candidate.Species is not null && !_species.Any(x => string.Equals(x, candidate.Species));
    }
}
