using Domain.DL.Models.UserModels;

namespace Domain.IPL.Repositories;
public interface IUserRepository
{
    public void AddUser(User entity);
    public void UpdateUser(User entity);
    public void DeactivateUser(User entity);
    public Task<User> GetForOperationAsync(int id);
    public Task<bool> IsLoginInformationCorrectAsync(string username, string hashedPassword);
}
