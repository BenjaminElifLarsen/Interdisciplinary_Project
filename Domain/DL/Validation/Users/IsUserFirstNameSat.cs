using Domain.DL.CQRS.Commands.Users;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Users;
internal sealed class IsUserFirstNameSat : ISpecification<RegistrateUser>
{
    public bool IsSatisfiedBy(RegistrateUser candidate)
    {
        return !string.IsNullOrWhiteSpace(candidate.FirstName);
    }
}
