using Domain.DL.Models.MessageModels;
using Domain.IPL.Repositories.Specifications.Messasges;
using Shared.CQRS.Queries;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories.Messages;
public class MessageAuthorRepository : IMessageAuthorRepository
{
    private readonly IBaseRepository<Author, int> _repository;

    public MessageAuthorRepository(IBaseRepository<Author, int> repository)
    {
        _repository = repository;
    }

    public void Add(Author entity)
    {
        _repository.Create(entity);        
    }

    public void Delete(Author entity)
    {
        _repository.Delete(entity);
    }

    public async Task<Author> GetForOperationAsync(int id)
    {
        return await _repository.FindByPredicateForOperationAsync(new ByUserId(id), x => x.Messages);
    }

    public async Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Author, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.FindByPredicateAsync(new ByUserId(id), query);
    }

    public void Update(Author entity)
    {
        _repository.Update(entity);
    }

    public async Task<IEnumerable<Author>> GetUsersThatHaveLikedAMessageForOperation(int messageId)
    { // will need a specification for this, return true if user.Likes contain a specific messageId
        return await _repository.AllByPredicateForOperationAsync(new ByLikedMessageId(messageId));
    }
}
