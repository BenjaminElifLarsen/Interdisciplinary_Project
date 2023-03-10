using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
public class AnimalSpecies : BaseReadModel
{
    public string Species { get; set; }

	public AnimalSpecies(string species)
	{
		Species = species;
	}
}

public class AnimalSpeciesQuery : BaseQuery<Animalia, LifeformSpecies>
{
    public override Expression<Func<Animalia, LifeformSpecies>> Map()
    {
        return e => new(e.Species);
    }
}
