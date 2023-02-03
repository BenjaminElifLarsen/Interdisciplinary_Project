using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Lifeforms.Queries.GetSinglePlant;
public class PlantDetails : BaseReadModel
{
    public string Species { get; private set; }
    public double MaximumPossibleHeight { get; private set; }

    public PlantDetails(string species, double maximumPossibleHeight)
    {
        Species = species;
        MaximumPossibleHeight = maximumPossibleHeight;
    }
}

public class PlantDetailsQuery : BaseQuery<Plantae, PlantDetails>
{
    public override Expression<Func<Plantae, PlantDetails>> Map()
    {
        return e => new(e.Species, e.MaximumHeight);
    }
}
