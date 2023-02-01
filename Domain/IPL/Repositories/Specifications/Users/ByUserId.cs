using Domain.DL.Models.UserModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Users;
internal sealed class ByUserId : ISpecification<User>
{
    private readonly int _id;
    public ByUserId(int id)
    {
        _id = id;
    }

    public bool IsSatisfiedBy(User candidate)
    {
        return candidate.Id == _id;
    }
}
