using Domain.DL.CQRS.Commands.Users;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Users;
internal sealed class IsUserPasswordAndConfirmedPasswordTheSame : ISpecification<RegistrateUser>
{
    public bool IsSatisfiedBy(RegistrateUser candidate)
    {
        return string.Equals(candidate.Password, candidate.ConfirmPassword);
    }
}
