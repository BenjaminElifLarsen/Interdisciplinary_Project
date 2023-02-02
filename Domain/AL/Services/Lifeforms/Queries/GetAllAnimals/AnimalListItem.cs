using Shared.CQRS.Queries;

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
