using Domain.DL.Models.MessageModels;
using Shared.CQRS.Queries;

namespace Domain.IPL.Repositories;
public interface IMessageRepository
{
    public void AddMessage(Message entity);
    public void UpdateMessage(Message entity);
    public void DeleteMessage(Message entity);
    public Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<Message, TMapping> query) where TMapping : BaseReadModel;
    public Task<Message> GetForOperationAsync(int id);
    public Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Message, TMapping> query) where TMapping : BaseReadModel;
}
