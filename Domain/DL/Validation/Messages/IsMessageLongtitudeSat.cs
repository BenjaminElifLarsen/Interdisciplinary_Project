using Domain.DL.CQRS.Commands.Messages;
using Shared.SpecificationPattern;

namespace Domain.DL.Validation.Messages;
internal class IsMessageLongtitudeSat : ISpecification<InsertMessage>
{
    public bool IsSatisfiedBy(InsertMessage candidate)
    {
        return candidate.Longtitude >= 0;
    }
}
