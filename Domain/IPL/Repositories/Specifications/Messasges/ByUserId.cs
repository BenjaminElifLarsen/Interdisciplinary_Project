using Domain.DL.Models.MessageModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Messasges;
internal class ByUserId : ISpecification<Message>
{
    private readonly int _userId;

    public ByUserId(int userId)
    {
        _userId = userId;
    }

    public bool IsSatisfiedBy(Message candidate)
    {
        return candidate.Author.AuthorUserId == _userId;
    }
}
