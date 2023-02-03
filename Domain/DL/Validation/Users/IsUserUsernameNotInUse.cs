using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Users;
internal sealed class IsUserUsernameNotInUse : ISpecification<RegistrateUser>
{
    private IEnumerable<UserUsername> _userNames;

    public IsUserUsernameNotInUse(IEnumerable<UserUsername> userNames)
    {
        _userNames = userNames;
    }

    public bool IsSatisfiedBy(RegistrateUser candidate)
    {
        return candidate.Username is not null && !_userNames.Any(x => string.Equals(x.Username, candidate.Username));
    }
}
