using Domain.DL.Models.MessageModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Messasges;
internal class ByUserId : ISpecification<Message>, ISpecification<Author>
{
    private readonly int _userId;

    public ByUserId(int userId)
    {
        _userId = userId;
    }

    public bool IsSatisfiedBy(Message candidate)
    {
        return candidate.Author.Id == _userId;
    }

    public bool IsSatisfiedBy(Author candidate)
    {
        return candidate.Id == _userId;
    }
}
