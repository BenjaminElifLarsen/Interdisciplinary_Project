using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
internal class AnimalSpecies : BaseReadModel
{
    public string Species { get; set; }

	public AnimalSpecies(string species)
	{
		Species = species;
	}
}

internal class AnimnalSpeciesQuery : BaseQuery<Animalia, AnimalSpecies>
{
    public override Expression<Func<Animalia, AnimalSpecies>> Map()
    {
        return e => new(e.Species);
    }
}
