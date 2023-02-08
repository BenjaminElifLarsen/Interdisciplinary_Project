using Domain.DL.Models.UserModels;
using Shared.CQRS.Queries;

namespace Domain.IPL.Repositories;
public interface IUserRepository
{
    public void AddUser(User entity);
    public void UpdateUser(User entity);
    public void DeactivateUser(User entity);
    public Task<User> GetForOperationAsync(int id);
    public Task<bool> IsLoginInformationCorrectAsync(string username, string password);
    public Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<User, TMapping> query) where TMapping : BaseReadModel;
    public Task<IEnumerable<User>> GetUsersThatHaveLikedAMessageForOperation(int messageId);
}
