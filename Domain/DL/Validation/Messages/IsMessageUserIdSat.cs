using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal sealed class IsMessageUserIdSat : ISpecification<PostMessage>
{
    public bool IsSatisfiedBy(PostMessage candidate)
    {
        return candidate.UserId > 0;
    }
}
