using Domain.DL.Models.UserModels.ValueObjects;
using Shared.DDD;
using Shared.Test;

namespace Domain.DL.Models.UserModels;
public sealed class User : IAggregateRoot<int>, ITestSetId<int>
{
    private int _id;
    private Name _name;
    private string _userName;
    private string _hashedPassword;

    public int Id { get => _id; private set => _id = value; }
    public Name Name { get => _name; private set => _name = value; }
    public string FirstName => _name.FirstName;
    public string LastName => _name.LastName;
    public string Username { get => _userName; private set => _userName = value; }
    public string HashedPassword { get => _hashedPassword; private set => _hashedPassword = value; }


    private User()
    {

    }

    public User(Name name, string username, string hashedPassword)
    {
        _name = name;
        _userName = username;
        _hashedPassword = hashedPassword;
    }

    public void SetTestId(int id)
    {
        _id = id;
    }
}
