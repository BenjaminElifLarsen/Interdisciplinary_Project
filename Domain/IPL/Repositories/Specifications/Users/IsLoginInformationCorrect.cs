using Domain.DL.Models.UserModels;
using Shared.SpecificationPattern;

namespace Domain.IPL.Repositories.Specifications.Users;
internal class IsLoginInformationCorrect : ISpecification<User>
{ 
    private string Username { get; set; }
    private string HashedPassword { get; set; }

    public IsLoginInformationCorrect(string username, string hashedPassword)
    {
        Username = username;
        HashedPassword = hashedPassword;
    }

    public bool IsSatisfiedBy(User candidate)
    {
        return string.Equals(candidate.Username, Username) && string.Equals(candidate.HashedPassword, HashedPassword); 
    }
}
