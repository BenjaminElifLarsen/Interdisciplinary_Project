using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal class IsMessageTitleSat : ISpecification<PostMessage>
{
    public bool IsSatisfiedBy(PostMessage candidate)
    {
        return !string.IsNullOrWhiteSpace(candidate.Title);
    }
}
