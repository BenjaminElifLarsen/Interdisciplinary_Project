﻿using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal sealed class IsMessageUserIdValid : ISpecification<InsertMessage>
{
    private IEnumerable<int> _ids;

    public IsMessageUserIdValid(IEnumerable<int> ids)
    {
        _ids = ids;
    }

    public bool IsSatisfiedBy(InsertMessage candidate)
    {
        return _ids.Any(x => x == candidate.UserId);
    }
}