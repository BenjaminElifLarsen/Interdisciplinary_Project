using Domain.DL.Models.UserModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
internal class UserId : BaseReadModel
{
    public int Id { get; set; }

    public UserId(int id)
    {
        Id = id;
    }
}

internal class UserIdQuery : BaseQuery<User, UserId>
{
    public override Expression<Func<User, UserId>> Map()
    {
        return e => new(e.Id);
    }
}
