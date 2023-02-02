using Domain.DL.CQRS.Commands.Users;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Users;
internal sealed class IsUserUsernameNotInUse : ISpecification<RegistrateUser>
{
    private IEnumerable<string> _userNames;

    public IsUserUsernameNotInUse(IEnumerable<string> userNames)
    {
        _userNames = userNames;
    }

    public bool IsSatisfiedBy(RegistrateUser candidate)
    {
        return candidate.Username is not null && _userNames.Any(x => string.Equals(x, candidate.Username));
    }
}
