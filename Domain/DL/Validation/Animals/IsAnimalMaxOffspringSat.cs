using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Animals;
internal sealed class IsAnimalMaxOffspringSat : ISpecification<RecogniseAnimal>, ISpecification<ChangeAnimalInformation>
{
    public bool IsSatisfiedBy(RecogniseAnimal candidate)
    {
        return IsSatisfiedBy(candidate.MaxAmountOfOffspring);
    }

    public bool IsSatisfiedBy(ChangeAnimalInformation candidate)
    {
        return candidate.MaximumOffspring is null || IsSatisfiedBy(candidate.MaximumOffspring.MaximumOffspring);
    }

    private bool IsSatisfiedBy(byte candidate)
    {
        return candidate != 0;
    }
}
