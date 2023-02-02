using Domain.DL.CQRS.Commands.Users;

namespace Domain.DL.Validation;
internal sealed class UserValidator
{
	private readonly RegistrateUser _user;
	private readonly UserValidationData _validationData;

	public UserValidator()
	{

	}
}

internal sealed class UserValidationData
{
    public IEnumerable<string> Usernames { get; private set; }

	public UserValidationData(IEnumerable<string> usernames)
	{
		Usernames = usernames;
	}
}