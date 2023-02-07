using Domain.DL.Models.MessageModels;
using Domain.IPL.Repositories.Specifications.Messasges;
using Shared.CQRS.Queries;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories;
public class MessageRepository : IMessageRepository
{
    private readonly IBaseRepository<Message, int> _repository;

    public MessageRepository(IBaseRepository<Message, int> repository)
    {
        _repository = repository;
    }

    public void AddMessage(Message entity)
    {
        _repository.Create(entity);
    }

    public async Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Message, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.AllAsync(query);
    }

    public async Task<IEnumerable<TMapping>> AllFromUser<TMapping>(int id, BaseQuery<Message, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.AllByPredicateAsync(new ByUserId(id), query);
    }

    public void DeleteMessage(Message entity)
    {
        _repository.Delete(entity);
    }

    public async Task<Message> GetForOperationAsync(int id)
    {
        return await _repository.FindByPredicateForOperationAsync(new ByMessageId(id));
    }

    public async Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Message, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.FindByPredicateAsync(new ByMessageId(id), query);
    }

    public void UpdateMessage(Message entity)
    {
        _repository.Update(entity);
    }
}
