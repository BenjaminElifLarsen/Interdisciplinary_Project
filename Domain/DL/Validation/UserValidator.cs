using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Validation.Users;
using Shared.SpecificationPattern.Composite.Extensions;
using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.UserErrors;

namespace Domain.DL.Validation;
internal sealed class UserValidator
{
	private readonly RegistrateUser _user;
	private readonly UserValidationData _validationData;

	public UserValidator(RegistrateUser user, UserValidationData validationData)
	{
		_user = user;
		_validationData = validationData;
	}

	public BinaryFlag Validate()
	{
		BinaryFlag flag = new();
		flag += new IsUserFirstNameSat().IsSatisfiedBy(_user) ? 0 : FirstNameInvalid;
		flag += new IsUserLastNameSat().IsSatisfiedBy(_user) ? 0 : LastNameInvalid;
		flag += new IsUserUsernameSat().And(new IsUserUsernameNotInUse(_validationData.Usernames)).IsSatisfiedBy(_user) ? 0 : UsernameInvalid;
		flag += new IsUserPasswordSat().IsSatisfiedBy(_user) ? 0 : PasswordNotSat;
		flag += new IsUserConfirmPasswordSat().IsSatisfiedBy(_user) ? 0 : ConfirmPasswordNotSat;
		flag += new IsUserPasswordAndConfirmedPasswordTheSame().IsSatisfiedBy(_user) ? 0 : PasswordAndConfirmPasswordNotSame;
		return flag;
	}
}

public sealed class UserValidationData
{
    public IEnumerable<string> Usernames { get; private set; }

	public UserValidationData(IEnumerable<string> usernames)
	{
		Usernames = usernames;
	}
}