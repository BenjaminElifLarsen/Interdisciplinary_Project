using Shared.DDD;

namespace Domain.DL.Models.UserModels.ValueObjects;
public sealed record Like : ValueObject
{
    private User _user;
    private int _userId;
    private int _messageId;

    public User User { get => _user; private set => _user = value; }
    public int UserId { get => _userId; private set => _userId = value; }
    public int MessageId { get => _messageId; private set => _messageId = value; }

    private Like()
    {

    }

    public Like(int userId, int messageId)
    {
        _userId = userId;
        _messageId = messageId;
    }
}
