using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Models.MessageModels;
using Domain.DL.Validation;
using Shared.ResultPattern.Abstract;

namespace Domain.DL.Factories;
public interface IMessageFactory
{
    //Domain driven design ubiquitous language does not care about names related to non-domain models, like factories and repositories.
    /// <summary>
    /// Creates a message out from <paramref name="data"/>.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public Result<Message> CreateMessage(PostMessage data, MessageValidationData validationData);
}
