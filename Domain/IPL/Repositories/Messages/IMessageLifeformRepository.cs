using Domain.DL.Models.MessageModels;

namespace Domain.IPL.Repositories.Messages;
public interface IMessageLifeformRepository
{
    public void Add(Lifeform entity);
    public void Update(Lifeform entity);
    public void Delete(Lifeform entity);
    public Task<Lifeform> GetForOperationAsync(int id);
}
