using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Plants;
internal sealed class IsPlantMaximumHeightValid : ISpecification<RecognisePlant>, ISpecification<ChangePlantInformation>
{
    public bool IsSatisfiedBy(RecognisePlant candidate)
    {
        return IsSatisfiedBy(candidate.PossibleMaximumHeight);
    }

    public bool IsSatisfiedBy(ChangePlantInformation candidate)
    {
        return candidate.MaximumHeight is null || IsSatisfiedBy(candidate.MaximumHeight.MaximumHeight);
    }

    private bool IsSatisfiedBy(double candidate)
    {
        return candidate > 0;
    }
}
