using Shared.CQRS.Queries;

namespace Domain.DL.Validation.ReadModels;
public class LifeformSpecies : BaseReadModel
{
    public string Species { get; set; }

	public LifeformSpecies(string species)
	{
		Species = species;
	}
}