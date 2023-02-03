using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal sealed class IsMessageUserIdValid : ISpecification<PostMessage>
{
    private IEnumerable<UserId> _ids;

    public IsMessageUserIdValid(IEnumerable<UserId> ids)
    {
        _ids = ids;
    }

    public bool IsSatisfiedBy(PostMessage candidate)
    {
        return _ids.Any(x => x.Id == candidate.UserId);
    }
}
