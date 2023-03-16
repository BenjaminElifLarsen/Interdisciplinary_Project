using Shared.DDD;
using Shared.Test;

namespace Domain.DL.Models.LifeformModels;
public abstract class Eukaryote : IAggregateRoot<int>, ITestSetId<int>
{
    private int _id;
    private string _speciesName; //value object with species and language, e.g. Danish or Latin

    public int Id { get => _id; private set => _id = value; }
    public string Species { get => _speciesName; private set => _speciesName = value; }

    protected Eukaryote()
    { //for Entityframework core

    }

    public Eukaryote(string name)
    {
        _speciesName = name;
    }


    internal void ChangeSpecies(string species)
    {
        _speciesName = species;
    }

    public void SetTestId(int id)
    {
        _id = id;
    }
}
