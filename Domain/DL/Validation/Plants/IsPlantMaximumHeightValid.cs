using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Plants;
internal sealed class IsPlantMaximumHeightValid : ISpecification<RecognisePlant>
{
    public bool IsSatisfiedBy(RecognisePlant candidate)
    {
        return candidate.PossibleMaximumHeight > 0;
    }
}
