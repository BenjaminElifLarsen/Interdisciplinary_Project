using Domain.DL.Models.MessageModels;
using Domain.IPL.Repositories.Specifications.Messasges;
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
        return await _repository.FindByPredicateForOperationAsync(new ByUserId(id));
    }

    public void Update(Author entity)
    {
        _repository.Update(entity);
    }
}
