using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal sealed class IsMessageEukaryoteIdValid : ISpecification<PostMessage>
{
    private IEnumerable<int> _ids;

    public IsMessageEukaryoteIdValid(IEnumerable<int> ids)
    {
        _ids = ids;
    }

    public bool IsSatisfiedBy(PostMessage candidate)
    {
        return _ids.Any(x => x == candidate.EukaryoteId);
    }
}
