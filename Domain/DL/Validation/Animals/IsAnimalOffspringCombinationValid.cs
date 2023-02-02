using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Animals;
internal sealed class IsAnimalOffspringCombinationValid : ISpecification<RecogniseAnimal>
{
    public bool IsSatisfiedBy(RecogniseAnimal candidate)
    {
        return candidate.MinAmountOfOffspring <= candidate.MaxAmountOfOffspring;
    }
}
