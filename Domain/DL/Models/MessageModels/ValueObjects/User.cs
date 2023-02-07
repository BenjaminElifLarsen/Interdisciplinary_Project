using Shared.DDD;

namespace Domain.DL.Models.MessageModels.ValueObjects;
public sealed record User : ValueObject
{ //should be a aggregate root in a real ddd system
    private int _userUserId;

    public int UserUserId { get => _userUserId; private set => _userUserId = value; }

    private User()
    {

    }

    public User(int id)
    {
        _userUserId = id;
    }
}
