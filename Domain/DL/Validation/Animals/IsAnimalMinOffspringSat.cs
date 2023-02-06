using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Animals;
internal sealed class IsAnimalMinOffspringSat : ISpecification<RecogniseAnimal>, ISpecification<ChangeAnimalInformation>
{
    public bool IsSatisfiedBy(RecogniseAnimal candidate)
    {
        return IsSatisfiedBy(candidate.MinAmountOfOffspring);
    }

    public bool IsSatisfiedBy(ChangeAnimalInformation candidate)
    {
        return candidate.MinimumOffspring is null || IsSatisfiedBy(candidate.MinimumOffspring.MinimumOffspring);
    }

    private bool IsSatisfiedBy(byte candidate)
    {
        return candidate != 0;
    }
}
