using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Users;
public sealed class RegistrateUser : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public RegistrateUser()
    {
        
    }

    /// <summary>
    /// Only used for seeding
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    internal RegistrateUser(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
