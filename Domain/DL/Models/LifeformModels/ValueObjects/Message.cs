using Shared.DDD;

namespace Domain.DL.Models.LifeformModels.ValueObjects;
public sealed record AnimalMessage : ValueObject
{
    private int _messageMessageId;

    public int MessageMessageId { get => _messageMessageId; private set => _messageMessageId = value; }

    private AnimalMessage()
    {

    }

    public AnimalMessage(int id)
    {
        _messageMessageId = id;

    }
}

public sealed record PlantMessage : ValueObject
{
    private int _messageMessageId;

    public int MessageMessageId { get => _messageMessageId; private set => _messageMessageId = value; }

    private PlantMessage()
    {

    }

    public PlantMessage(int id)
    {
        _messageMessageId = id;

    }
}