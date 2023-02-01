using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Animals;
internal sealed class IsAnimalSpeciesSat : ISpecification<RecogniseAnimal>
{
    public bool IsSatisfiedBy(RecogniseAnimal candidate)
    {
        return !string.IsNullOrWhiteSpace(candidate.Species);
    }
}
