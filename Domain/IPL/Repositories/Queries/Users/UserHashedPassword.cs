using Domain.DL.Models.UserModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.IPL.Repositories.Queries.Users;
internal class UserHashedPassword : BaseReadModel
{
    public string HashedPassword { get; private set; }

	public UserHashedPassword(string hashedPassword)
	{
		HashedPassword = hashedPassword;
	}
}

internal class UserHashedPasswordQuery : BaseQuery<User, UserHashedPassword>
{
    public override Expression<Func<User, UserHashedPassword>> Map()
    {
        return e => new(e.HashedPassword);
    }
}
