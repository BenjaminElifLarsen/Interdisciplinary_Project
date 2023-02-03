using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Lifeforms.Queries.GetSingleAnimal;
public class AnimalDetails : BaseReadModel
{
    public string Species { get; private set; }
    public bool IsBird { get; private set; }
    public byte MaximumOffspring { get; private set; }
    public byte MinimumOffspring { get; private set; }

    public AnimalDetails(string species, bool isBird, byte maxOffspring, byte minOffspring)
    {
        Species = species;
        IsBird = isBird;
        MaximumOffspring = maxOffspring;
        MinimumOffspring = minOffspring;
    }
}

public class AnimalDetailsQuery : BaseQuery<Animalia, AnimalDetails>
{
    public override Expression<Func<Animalia, AnimalDetails>> Map()
    {
        return e => new(e.Species, e.IsBird, e.MaximumOffspringsPerMating, e.MinimumOffspringsPerMating);
    }
}
