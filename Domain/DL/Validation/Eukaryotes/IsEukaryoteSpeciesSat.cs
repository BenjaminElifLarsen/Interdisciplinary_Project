using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Eukaryotes;
internal class IsEukaryoteSpeciesSat : ISpecification<ChangeLifeformInformation>
{
    public bool IsSatisfiedBy(ChangeLifeformInformation candidate)
    {
        return candidate.Species is null || !string.IsNullOrWhiteSpace(candidate.Species.Species);
    }
}
