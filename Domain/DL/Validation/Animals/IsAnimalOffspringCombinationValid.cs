using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Animals;
internal sealed class IsAnimalOffspringCombinationValid : ISpecification<RecogniseAnimal>, ISpecification<(ChangeAnimalInformation request, AnimalOffspringInformation current)>//, ISpecification<ChangeAnimalInformation>
{
    public bool IsSatisfiedBy(RecogniseAnimal candidate)
    {
        return candidate.MinAmountOfOffspring <= candidate.MaxAmountOfOffspring;
    }

    public bool IsSatisfiedBy((ChangeAnimalInformation request, AnimalOffspringInformation current) candidate)
    {
        if(candidate.request.MaximumOffspring is not null && candidate.request.MinimumOffspring is not null)
        {
            return candidate.request.MinimumOffspring.MinimumOffspring <= candidate.request.MaximumOffspring.MaximumOffspring;
        }
        else if(candidate.request.MaximumOffspring is not null)
        {
            return candidate.current.CurrentMin <= candidate.request.MaximumOffspring.MaximumOffspring;
        }
        else if(candidate.request.MinimumOffspring is not null)
        {
            return candidate.request.MinimumOffspring.MinimumOffspring <= candidate.current.CurrentMax;
        }
        return true;
    }
}
