
using Domain.DL.CQRS.Commands.Messages;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Messages;
public partial class MessageService : IMessageService
{
    public async Task<Result> PostMessageAsync(PostMessage command)
    {
        return await Task.Run(() => _commandBus.Dispatch(command));
    }
}
