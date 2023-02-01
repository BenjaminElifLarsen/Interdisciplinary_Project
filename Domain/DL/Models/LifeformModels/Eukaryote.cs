using Shared.DDD;

namespace Domain.DL.Models.LifeformModels;
public abstract class Eukaryote : IAggregateRoot<int>
{
    private int _id;
    private string _speciesName; //value object with species and language, e.g. Danish or Latin
    private ulong _observationAmount;
    public int Id { get => _id; private set => _id = value; }
    public string Species { get => _speciesName; }
    public ulong TotalObservationTimes { get => _observationAmount; }
    protected Eukaryote()
    { //for Entityframework core

    }

    public Eukaryote(string name)
    {
        _speciesName = name;
        _observationAmount = 0;
    }

    public void BeenObservered()
    {
        _observationAmount++;
    }

}
