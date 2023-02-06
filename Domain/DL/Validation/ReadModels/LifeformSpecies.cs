using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
internal class LifeformSpecies : BaseReadModel
{
    public string Species { get; set; }

	public LifeformSpecies(string species)
	{
		Species = species;
	}
}