using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal class IsMessageEukaryoteIdSat : ISpecification<InsertMessage>
{
    public bool IsSatisfiedBy(InsertMessage candidate)
    {
        return candidate.EukaryoteId > 0;
    }
}
