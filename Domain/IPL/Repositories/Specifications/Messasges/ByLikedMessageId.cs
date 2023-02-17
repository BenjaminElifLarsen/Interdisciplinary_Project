using Domain.DL.Models.MessageModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Messasges;
internal class ByLikedMessageId : ISpecification<Author>
{
    private int _messageId;

    public ByLikedMessageId(int messageId)
    {
        _messageId = messageId;
    }

    public bool IsSatisfiedBy(Author candidate)
    {
        return candidate.Likes.Any(x => x.MessageId == _messageId);
    }
}
