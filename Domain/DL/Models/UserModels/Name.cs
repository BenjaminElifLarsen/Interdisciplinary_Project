using Shared.DDD;

namespace Domain.DL.Models.UserModels;
public sealed record Name : ValueObject
{
    private string _firstName;
    private string _lastName;

    public string FirstName { get => _firstName; private set => _firstName = value; }
    public string LastName { get => _lastName; private set => _lastName = value; }

    private Name()
    {
            
    }

    public Name(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }
}
