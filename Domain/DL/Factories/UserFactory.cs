using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Errors;
using Domain.DL.Models.UserModels;
using Domain.DL.Validation;
using Shared.Encryption;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;
using SharedImplementation.BinaryFlag;

namespace Domain.DL.Factories;
public class UserFactory : IUserFactory
{
    public Result<User> CreateUser(RegistrateUser creationData, UserValidationData validationData)
    {
        BinaryFlag flag = new UserValidator(creationData, validationData).Validate();
        if (flag)
        {
            string hashedPassword = PasswordEncryption.HashAndSalt(creationData.Password);
            User entity = new(new(creationData.FirstName, creationData.LastName), creationData.Username, hashedPassword);
            return new SuccessResult<User>(entity);
        }
        else
        {
            var errors = UserErrorConversion.Convert(flag);
            return new InvalidResult<User>(errors);
        }
    }


}
