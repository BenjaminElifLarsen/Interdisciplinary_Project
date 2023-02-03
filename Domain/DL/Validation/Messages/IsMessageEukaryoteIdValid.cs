using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal sealed class IsMessageEukaryoteIdValid : ISpecification<PostMessage>
{
    private IEnumerable<LifeformId> _ids;

    public IsMessageEukaryoteIdValid(IEnumerable<LifeformId> ids)
    {
        _ids = ids;
    }

    public bool IsSatisfiedBy(PostMessage candidate)
    {
        return _ids.Any(x => x.Id == candidate.EukaryoteId);
    }
}
