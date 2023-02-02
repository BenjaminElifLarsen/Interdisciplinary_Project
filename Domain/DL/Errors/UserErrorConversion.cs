using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.UserErrors;

namespace Domain.DL.Errors;
internal sealed class UserErrorConversion
{
    public static IEnumerable<string> Convert(BinaryFlag flag)
    {
        List<string> errors = new();
        if (flag == UsernameInvalid)
        {
            errors.Add("The username is invalid.");
        }
        if (flag == FirstNameInvalid)
        {
            errors.Add("The first name is invalid.");
        }
        if (flag == LastNameInvalid)
        {
            errors.Add("The last name is invalid.");
        }
        if (flag == PasswordNotSat)
        {
            errors.Add("The password is not sat.");
        }
        if (flag == ConfirmPasswordNotSat)
        {
            errors.Add("The confirm password is not sat.");
        }
        if (flag == PasswordAndConfirmPasswordNotSame)
        {
            errors.Add("The password and confirm password do not match.");
        }
        return errors;
    }
}
