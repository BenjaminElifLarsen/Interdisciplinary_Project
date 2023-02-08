using Domain.DL.Models.UserModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Users;
internal class ByLikedMessageId : ISpecification<User>
{
    private int _messageId;

	public ByLikedMessageId(int messageId)
	{
		_messageId = messageId;
	}

    public bool IsSatisfiedBy(User candidate)
    {
        return candidate.Likes.Any(x => x.MessageId == _messageId);
    }
}
