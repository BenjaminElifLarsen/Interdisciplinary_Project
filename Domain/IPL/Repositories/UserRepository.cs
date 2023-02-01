using Domain.DL.Models.UserModels;
using Domain.IPL.Repositories.Specifications.Users;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories;
internal class UserRepository : IUserRepository
{
    private readonly IBaseRepository<User, int> _repository;

    public UserRepository(IBaseRepository<User, int> repository)
    {
        _repository = repository;
    }

    public void AddUser(User entity)
    {
        _repository.Create(entity);
    }

    public void DeactivateUser(User entity)
    {
        _repository.Delete(entity);
    }

    public async Task<User> GetForOperationAsync(int id)
    {
        return await _repository.FindByPredicateForOperationAsync(new ByUserId(id));
    }

    public async Task<bool> IsLoginInformationCorrectAsync(string username, string hashedPassword)
    {
        return await _repository.IsUniqueAsync(new IsLoginInformationCorrect(username, hashedPassword));
    }

    public void UpdateUser(User entity)
    {
        _repository.Update(entity);
    }
}
