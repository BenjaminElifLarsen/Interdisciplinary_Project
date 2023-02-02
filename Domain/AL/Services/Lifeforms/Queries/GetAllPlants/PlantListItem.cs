using Shared.CQRS.Queries;

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
