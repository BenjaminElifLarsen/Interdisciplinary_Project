using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal sealed class IsMessageEukaryoteIdSat : ISpecification<PostMessage>
{
    public bool IsSatisfiedBy(PostMessage candidate)
    {
        return candidate.EukaryoteId > 0;
    }
}
