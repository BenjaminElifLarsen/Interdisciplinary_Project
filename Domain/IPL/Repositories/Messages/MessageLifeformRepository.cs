using Domain.DL.Models.MessageModels;
using Domain.IPL.Repositories.Specifications.Messasges;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories.Messages;
public class MessageLifeformRepository : IMessageLifeformRepository
{
    private readonly IBaseRepository<Lifeform, int> _repository;

    public MessageLifeformRepository(IBaseRepository<Lifeform, int> repository)
    {
        _repository = repository;            
    }

    public void Add(Lifeform entity)
    {
        _repository.Create(entity);
    }

    public void Delete(Lifeform entity)
    {
        _repository.Delete(entity);
    }

    public async Task<Lifeform> GetForOperationAsync(int id)
    {
        return await _repository.FindByPredicateForOperationAsync(new ByLifeformId(id));
    }

    public void Update(Lifeform entity)
    {
        _repository.Update(entity);
    }
}
