using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Plants;
internal sealed class IsPlantSpeciesSat : ISpecification<RecognisePlant>
{
    public bool IsSatisfiedBy(RecognisePlant candidate)
    {
        return !string.IsNullOrWhiteSpace(candidate.Species);
    }
}
