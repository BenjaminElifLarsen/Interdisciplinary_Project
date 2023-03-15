using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public sealed record Lifeform : IAggregateRoot<int>
{ //should be an aggregate root in a real ddd system
    private int _id;

    private HashSet<Message> _messages;

    public int Id { get => _id; private set => _id = value; }
    public IEnumerable<Message> Messages => _messages;


    private Lifeform()
    {

    }

    public Lifeform(int id)
    {
        _id = id;
        _messages = new();
    }

    internal void AddMessage(Message message)
    {
        _messages.Add(message);
    }

    internal void RemoveMessage(Message message)
    {
        _messages.Remove(message);
    }

    public void SetTestId(int id)
    {
        _id = id;
    }
}
