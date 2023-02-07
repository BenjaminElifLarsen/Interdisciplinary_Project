using Domain.DL.CQRS.Commands.Messages;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Messages;
public interface IMessageService
{
    public Task<Result> PostMessageAsync(PostMessage command);
    public Task<Result> LikeMessageAsync(LikeMessage command);
}
