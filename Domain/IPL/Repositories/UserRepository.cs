using Domain.DL.Models.UserModels;
using Domain.IPL.Repositories.Queries.Users;
using Domain.IPL.Repositories.Specifications.Users;
using Shared.CQRS.Queries;
using Shared.Encryption;
using Shared.RepositoryPattern;

namespace Domain.IPL.Repositories;
public class UserRepository : IUserRepository
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

    public async Task<IEnumerable<TMapping>> AllAsync<TMapping>(BaseQuery<User, TMapping> query) where TMapping : BaseReadModel
    {
        return await _repository.AllAsync(query);
    }

    public void DeactivateUser(User entity)
    {
        _repository.Delete(entity);
    }

    public async Task<User> GetForOperationAsync(int id)
    {
        return await _repository.FindByPredicateForOperationAsync(new ByUserId(id));
    }

    public async Task<IEnumerable<User>> GetUsersThatHaveLikedAMessageForOperation(int messageId)
    { // will need a specification for this, return true if user.Likes contain a specific messageId
        return await _repository.AllByPredicateForOperationAsync(new ByLikedMessageId(messageId));
    }

    public async Task<bool> IsLoginInformationCorrectAsync(string username, string password)
    {
        var user = await _repository.FindByPredicateAsync(new ByUserUsername(username), new UserHashedPasswordQuery()); 
        if (user is null) return false;
        char[] salt = user.HashedPassword[..44].Select(s => s).ToArray(); // Need more than the 32 byte in the salt since it is stored in base64
        string hashedPassword = PasswordEncryption.HashAndSalt(password, Convert.FromBase64String(new string(salt)));
        return await _repository.IsUniqueAsync(new IsLoginInformationCorrect(username, hashedPassword));
    } // https://github.com/BenjaminElifLarsen/basic/blob/main/LoginRepository.cs

    public void UpdateUser(User entity)
    {
        _repository.Update(entity);
    }
}
