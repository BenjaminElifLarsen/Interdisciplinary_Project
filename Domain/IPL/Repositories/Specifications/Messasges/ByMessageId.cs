using Domain.DL.Models.MessageModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Messasges;
internal class ByMessageId : ISpecification<Message>
{
    private readonly int _id;

    public ByMessageId(int id)
    {
        _id = id;
    }

    public bool IsSatisfiedBy(Message candidate)
    {
        return candidate.Id == _id;
    }
}
