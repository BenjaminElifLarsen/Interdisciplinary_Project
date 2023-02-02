using Domain.DL.Models.UserModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Users;
internal class ByUserUsername : ISpecification<User>
{
    private readonly string _username;

    public ByUserUsername(string username)
    {
        _username = username;
    }

    public bool IsSatisfiedBy(User candidate)
    {
        return string.Equals(candidate.Username, _username);
    }
}
