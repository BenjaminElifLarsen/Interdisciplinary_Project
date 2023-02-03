using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Lifeforms.Queries.GetAllAnimals;
public class AnimalListItem : BaseReadModel
{
    public int Id { get; private set; }
    public string Species { get; private set; }

    public AnimalListItem(int id, string species)
    {
        Id = id;
        Species = species;
    }
}

public class AnimalListQuery : BaseQuery<Animalia, AnimalListItem>
{
    public override Expression<Func<Animalia, AnimalListItem>> Map()
    {
        return e => new(e.Id, e.Species);
    }
}
