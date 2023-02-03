using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
//internal class AnimalId : BaseReadModel
//{
//    public int Id { get; set; }

//    public AnimalId(int id)
//    {
//        Id = id;
//    }
//}

internal class AnimalIdQuery : BaseQuery<Animalia, LifeformId>
{
    public override Expression<Func<Animalia, LifeformId>> Map()
    {
        return e => new(e.Id);
    }
}
