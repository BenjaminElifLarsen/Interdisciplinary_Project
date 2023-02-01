using Domain.DL.Models.MessageModels;
using Shared.DDD;

namespace Domain.DL.Models.UserModels;
public sealed class User : IAggregateRoot<int>
{
    private int _id;
    private Name _name;

    private HashSet<Message> _messages;

    public int Id { get => _id; private set => _id = value; }
    public Name Name { get => _name; private set => _name = value; }
    public string FirstName => _name.FirstName;
    public string LastName => _name.LastName;
    public IEnumerable<Message> Messages => _messages;

    private User()
    {

    }

    public User(Name name)
    {
        _name = name;        
    }
    //In a proper domain driven design there would be methods for adding and removing messages as there would be no direct relationship between the two models, they would only know of the ids of each other, nothing more.
}
