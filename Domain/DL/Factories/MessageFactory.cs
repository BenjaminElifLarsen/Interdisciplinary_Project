using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Models.MessageModels;
using Domain.DL.Validation;
using Shared.ResultPattern.Abstract;

namespace Domain.DL.Factories;
public class MessageFactory : IMessageFactory
{
    public Result<Message> CreateMessage(PostMessage data, MessageValidationData validationData)
    {
        throw new NotImplementedException();
    }
}
