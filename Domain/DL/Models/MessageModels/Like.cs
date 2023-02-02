using Domain.DL.Models.UserModels;
using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public sealed record Like : ValueObject
{
	private int _userId;
	private User _user; //proper ddd would not have this navigation route here and user would not know directly of the likes, only liked messages

	private int _messageId;
	private Message _message;

	private Like() //use Builder pattern for this class, maybe
	{

	}

	internal Like(int userId, int messageId)
	{
		_userId = userId;
		_messageId = messageId;
	}

	internal bool GotSpecificUserID(int userId) => _userId == userId;
}
