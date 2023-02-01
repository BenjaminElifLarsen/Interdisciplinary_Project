namespace Domain.DL.Models.UserModels;
public sealed record Name
{
    private string _firstName;
    private string _lastName;

    internal string FirstName { get => _firstName; private set => _firstName = value; }
    internal string LastName { get => _lastName; private set => _lastName = value; }

    private Name()
    {
            
    }

    public Name(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }
}
