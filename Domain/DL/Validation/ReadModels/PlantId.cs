using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
//internal class PlantId : BaseReadModel
//{
//    public int Id { get; set; }

//    public PlantId(int id)
//    {
//        Id = id;
//    }
//}

internal class PlantIdQuery : BaseQuery<Plantae, LifeformId>
{
    public override Expression<Func<Plantae, LifeformId>> Map()
    {
        return e => new(e.Id);
    }
}
