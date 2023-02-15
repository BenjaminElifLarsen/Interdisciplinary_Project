using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
internal class PlantSpecies : BaseReadModel
{
    public string Species { get; set; }

	public PlantSpecies(string species)
	{
		Species = species;
	}
}

public class PlantSpeciesQuery : BaseQuery<Plantae, LifeformSpecies>
{
    public override Expression<Func<Plantae, LifeformSpecies>> Map()
    {
        return e => new(e.Species);
    }
}
