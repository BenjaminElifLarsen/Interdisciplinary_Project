using Domain.DL.Models.LifeformModels.ValueObjects;
using Shared.DDD;

namespace Domain.DL.Models.LifeformModels;
public abstract class Eukaryote : IAggregateRoot<int>
{
    private int _id;
    private string _speciesName; //value object with species and language, e.g. Danish or Latin

    private HashSet<AnimalMessage> _messages;
    public IEnumerable<AnimalMessage> Messages => _messages;
    //public int TotalObservationTimes => _messages.Count();

    public int Id { get => _id; private set => _id = value; }
    public string Species { get => _speciesName; private set => _speciesName = value; }

    protected Eukaryote()
    { //for Entityframework core

    }

    public Eukaryote(string name)
    {
        _speciesName = name;
    }

    internal abstract void AddMessage(int messageId);
    internal abstract void RemoveMessage(int messageId);

    public void BeenObservered(int messageId)
    {
        //_messages.Add(new(messageId));
    }

    internal void ChangeSpecies(string species)
    {
        _speciesName = species;
    }
}
