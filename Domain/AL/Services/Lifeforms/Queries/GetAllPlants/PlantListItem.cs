using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Lifeforms.Queries.GetAllPlants;
public class PlantListItem : BaseReadModel
{
    public int Id { get; private set; }
    public string Species { get; private set; }

    public PlantListItem(int id, string species)
    {
        Id = id;
        Species = species;
    }
}

public class PlantListItemQuery : BaseQuery<Plantae, PlantListItem>
{
    public override Expression<Func<Plantae, PlantListItem>> Map()
    {
        return e => new(e.Id,e.Species);
    }
}
