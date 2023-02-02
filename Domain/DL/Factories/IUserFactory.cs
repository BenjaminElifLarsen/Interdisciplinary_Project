using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Models.UserModels;
using Domain.DL.Validation;
using Shared.ResultPattern.Abstract;

namespace Domain.DL.Factories;
public interface IUserFactory
{
    public Result<User> CreateUser(RegistrateUser creationData, UserValidationData validationData);
}
