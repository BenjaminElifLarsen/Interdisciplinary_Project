using Domain.DL.Models.UserModels.ValueObjects;
using Shared.DDD;

namespace Domain.DL.Models.UserModels;
public sealed class User : IAggregateRoot<int>
{
    private int _id;
    private Name _name;
    private string _userName;
    private string _hashedPassword;

    private HashSet<Message> _messages;
    private HashSet<Like> _likes;

    public int Id { get => _id; private set => _id = value; }
    public Name Name { get => _name; private set => _name = value; }
    public string FirstName => _name.FirstName;
    public string LastName => _name.LastName;
    public string Username { get => _userName; private set => _userName = value; }
    public string HashedPassword { get => _hashedPassword; private set => _hashedPassword = value; }

    public IEnumerable<Message> Messages => _messages; //own messages
    public IEnumerable<Like> Likes => _likes;

    private User()
    {

    }

    public User(Name name, string username, string hashedPassword)
    {
        _name = name;
        _userName = username;
        _hashedPassword = hashedPassword;
    }
    //In a proper domain driven design there would be methods for adding and removing messages as there would be no direct relationship between the two models, they would only know of the ids of each other, nothing more.

    public void AddLike(int messageId)
    {
        if (!_messages.Any(x => x.MessageMessageId == messageId))
            _likes.Add(new(_id, messageId));
    }

    public void RemoveLike(int messageId)
    {
        if(!_messages.Any(x => x.MessageMessageId == messageId))
            _likes.Remove(new(_id, messageId));
    }

    public void AddMessage(int messageId)
    {
        _messages.Add(new(messageId));
    }

    public void RemoveMessage(int messageId)
    {
        _messages.Remove(new(messageId));
    }
}
