
using Domain.AL.Services.Messages.Queries.GetOwn;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Messages;
public partial class MessageService : IMessageService
{
    public async Task<Result<IEnumerable<OwnMessageListItem>>> OwnMessagesAsync(int userId)
    {
        var list = await _unitOfWork.MessageRepository.AllFromUser(userId, new OwnMessageListQuery());
        return new SuccessResult<IEnumerable<OwnMessageListItem>>(list);
    }
}
