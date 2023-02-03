using Domain.DL.Models.UserModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
internal class UserUsername : BaseReadModel
{
    public string Username { get; set; }

    public UserUsername(string username)
    {
        Username = username;
    }
}

internal class UserUsernameQuery : BaseQuery<User, UserUsername>
{
    public override Expression<Func<User, UserUsername>> Map()
    {
        return e => new(e.Username);
    }
}