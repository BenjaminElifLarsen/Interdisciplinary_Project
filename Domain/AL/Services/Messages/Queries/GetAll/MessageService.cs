
using Domain.AL.Services.Messages.Queries.GetAll;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Messages;
public partial class MessageService : IMessageService
{
    public async Task<Result<IEnumerable<MessageListItem>>> AllMessagesAsync()
    {
        var list = await _unitOfWork.MessageRepository.AllAsync(new MessageListQuery());
        return new SuccessResult<IEnumerable<MessageListItem>>(list);
    }
}
