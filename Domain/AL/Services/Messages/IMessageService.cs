using Domain.AL.Services.Messages.Queries.GetAll;
using Domain.AL.Services.Messages.Queries.GetOwn;
using Domain.AL.Services.Messages.Queries.GetSingle;
using Domain.DL.CQRS.Commands.Messages;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Messages;
public interface IMessageService
{
    public Task<Result> PostMessageAsync(PostMessage command);
    public Task<Result> LikeMessageAsync(LikeMessage command);
    public Task<Result> HideMessageAsync(HideMessage command);

    public Task<Result<IEnumerable<OwnMessageListItem>>> OwnMessagesAsync(int userId);
    public Task<Result<IEnumerable<MessageListItem>>> AllMessagesAsync();
    public Task<Result<MessageDetails>> MessageDetailsAsync(int id);
}
