using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Errors;
using Domain.DL.Models.MessageModels;
using Domain.DL.Validation;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;
using SharedImplementation.BinaryFlag;

namespace Domain.DL.Factories;
public class MessageFactory : IMessageFactory
{
    public Result<Message> CreateMessage(PostMessage data, MessageValidationData validationData)
    {
        BinaryFlag flag = new MessageValidator(data, validationData).Validate();
        if (flag)
        {
            Message entity = new(data.Title, data.Text, data.UserId, data.EukaryoteId, new(data.Moment, data.Latitude, data.Longtitude));
            return new SuccessResult<Message>(entity);
        }
        return new InvalidResult<Message>(MessageErrorConversion.Convert(flag));
    }
}
