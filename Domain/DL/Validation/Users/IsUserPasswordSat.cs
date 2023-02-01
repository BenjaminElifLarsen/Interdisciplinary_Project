﻿using Domain.DL.CQRS.Commands.Users;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Users;
internal class IsUserPasswordSat : ISpecification<RegistrateUser>
{
    public bool IsSatisfiedBy(RegistrateUser candidate)
    {
        return !string.IsNullOrWhiteSpace(candidate.Password);
    }
}
