using Domain.DL.Models.MessageModels;
using Shared.CQRS.Queries;

namespace Domain.IPL.Repositories.Messages;
public interface IMessageAuthorRepository
{
    public void Add(Author entity);
    public void Update(Author entity);
    public void Delete(Author entity);
    public Task<Author> GetForOperationAsync(int id);
    public Task<TMapping> GetSingleAsync<TMapping>(int id, BaseQuery<Author, TMapping> query) where TMapping : BaseReadModel;
    public Task<IEnumerable<Author>> GetUsersThatHaveLikedAMessageForOperation(int messageId);
}
