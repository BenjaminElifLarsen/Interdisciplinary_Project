using Domain.DL.Models.MessageModels.ValueObjects;
using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public sealed record Author : IAggregateRoot<int>
{ //should be a aggregate root in a real ddd system
    private int _id;
    private string _username;

    private HashSet<Message> _messages;
    private HashSet<AuthorLike> _likes;

    public int Id { get => _id; private set => _id = value; }
    public string Username { get => _username; private set => _username= value; }

    /// <summary>
    /// Own messages.
    /// </summary>
    public IEnumerable<Message> Messages => _messages;
    public IEnumerable<AuthorLike> Likes => _likes;

    private Author()
    {

    }

    public Author(int id, string username)
    {
        _id = id;
        _username = username;
        _messages = new();
        _likes = new();
    }

    public void AddLike(int messageId)
    {
        if (!_messages.Any(x => x.Id == messageId) && !_likes.Any(x => x.MessageId == messageId))
            _likes.Add(new(_id, messageId));
    }

    public void RemoveLike(int messageId)
    {
        if (!_messages.Any(x => x.Id == messageId))
            _likes.Remove(_likes.SingleOrDefault(x => x.MessageId == messageId));
    }

    public void AddMessage(Message message)
    {
        _messages.Add(message);
    }

    public void RemoveMessage(Message message)
    {
        _messages.Remove(message);
    }

    public void SetTestId(int id)
    {
        _id = id;
    }
}
