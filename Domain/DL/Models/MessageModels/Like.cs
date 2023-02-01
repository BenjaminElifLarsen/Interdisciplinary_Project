using Domain.DL.Models.UserModels;
using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public record Like : ValueObject
{
	private int _userId;
	private User _user; //proper ddd would not have this navigation route here and user would not know directly of the likes, only liked messages

	private int _messageId;
	private Message _message;

	private Like()
	{

	}

	internal Like(int userId, int messageId)
	{
		_userId = userId;
		_messageId = messageId;
	}

	internal bool GotSpecificUserID(int userId) => _userId == userId;
}
