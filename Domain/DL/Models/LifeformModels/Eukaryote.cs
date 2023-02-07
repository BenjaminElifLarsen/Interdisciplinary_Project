using Shared.DDD;

namespace Domain.DL.Models.LifeformModels;
public abstract class Eukaryote : IAggregateRoot<int>
{
    private int _id;
    private string _speciesName; //value object with species and language, e.g. Danish or Latin

    public int Id { get => _id; private set => _id = value; }
    public string Species { get => _speciesName; private set => _speciesName = value; }
    public abstract bool BeenObservered { get; }

    protected Eukaryote()
    { //for Entityframework core

    }

    public Eukaryote(string name)
    {
        _speciesName = name;
    }

    internal abstract void AddMessage(int messageId);
    internal abstract void RemoveMessage(int messageId);

    internal void ChangeSpecies(string species)
    {
        _speciesName = species;
    }
}
