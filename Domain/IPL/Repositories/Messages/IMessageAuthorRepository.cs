using Domain.DL.Models.MessageModels;

namespace Domain.IPL.Repositories.Messages;
public interface IMessageAuthorRepository
{
    public void Add(Author entity);
    public void Update(Author entity);
    public void Delete(Author entity);
    public Task<Author> GetForOperationAsync(int id);
}
