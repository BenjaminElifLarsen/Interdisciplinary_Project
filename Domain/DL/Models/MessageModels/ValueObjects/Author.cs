using Shared.DDD;

namespace Domain.DL.Models.MessageModels.ValueObjects;
public sealed record Author : ValueObject
{ //should be a aggregate root in a real ddd system
    private int _authorUserId;

    public int AuthorUserId { get => _authorUserId; private set => _authorUserId = value; }

    private Author()
    {

    }

    public Author(int id)
    {
        _authorUserId = id;
    }
}
