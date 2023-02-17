using Domain.DL.Models.MessageModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Messasges;
internal class ByLifeformId : ISpecification<Lifeform>
{
    private readonly int _id;

    public ByLifeformId(int id)
    {
        _id = id;
    }

    public bool IsSatisfiedBy(Lifeform candidate)
    {
        return candidate.Id == _id;
    }
}
