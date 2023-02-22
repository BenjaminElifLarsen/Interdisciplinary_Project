using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Lifeforms.Queries.GetSingle;
public sealed class LifeformDetails : BaseReadModel
{
    public int Id { get; set; }
    public string Species { get; set; }

    public LifeformDetails(int id, string species)
    {
        Id = id;
        Species = species;
    }
}

internal sealed class LifeformDetailsQuery : BaseQuery<Eukaryote, LifeformDetails>
{
    public override Expression<Func<Eukaryote, LifeformDetails>> Map()
    {
        return e => new(e.Id, e.Species);
    }
}
