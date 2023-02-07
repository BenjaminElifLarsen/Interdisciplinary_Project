using Shared.DDD;

namespace Domain.DL.Models.MessageModels.ValueObjects;
public sealed record Eukaryote : ValueObject
{ //should be an aggregate root in a real ddd system
    private int _eukaryoteEukaryoteId;

    public int EukaryoteEukaryoteId { get => _eukaryoteEukaryoteId; private set => _eukaryoteEukaryoteId = value; }

    private Eukaryote()
    {

    }

    public Eukaryote(int id)
    {
        _eukaryoteEukaryoteId = id;
    }
}
