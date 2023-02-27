using Domain.DL.Models.UserModels;
using Shared.DDD;

namespace Domain.DL.Models.MessageModels.ValueObjects;
public sealed record AuthorLike : ValueObject
{
    private int _userId;
    //private User _user; //proper ddd would not have this navigation route here and user would not know directly of the likes, only liked messages
    //since this object is a set as non-owned in entity framework there are some problems with navigation keys and cascading on delete problems
    private int _messageId;
    //private Message _message;

    public int UserId { get => _userId; private set => _userId = value; }
    //public User User { get => _user; private set => _user = value; }
    public int MessageId { get => _messageId; private set => _messageId = value; }
    //public Message Message { get => _message; private set => _message = value; }

    private AuthorLike() //use Builder pattern for this class, maybe
    {

    }

    internal AuthorLike(int userId, int messageId)
    {
        _userId = userId;
        _messageId = messageId;
    }

    //internal bool GotSpecificUserID(int userId) => _userId == userId;
}
