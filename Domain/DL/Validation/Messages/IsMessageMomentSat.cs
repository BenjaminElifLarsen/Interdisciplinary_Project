﻿using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal sealed class IsMessageMomentSat : ISpecification<InsertMessage>
{
    public bool IsSatisfiedBy(InsertMessage candidate)
    {
        return candidate != default;
    }
}