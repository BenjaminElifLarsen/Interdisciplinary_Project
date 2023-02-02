using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Models.MessageModels;
using Shared.ResultPattern.Abstract;

namespace Domain.DL.Factories;
public class MessageFactory : IMessageFactory
{
    public Result<Message> CreateMessage(PostMessage data)
    {
        throw new NotImplementedException();
    }
}
