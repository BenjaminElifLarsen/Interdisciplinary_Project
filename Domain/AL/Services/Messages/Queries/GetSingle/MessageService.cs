using Domain.AL.Services.Messages.Queries.GetSingle;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.NotFound;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Messages;
public partial class MessageService : IMessageService
{
    public async Task<Result<MessageDetails>> MessageDetailsAsync(int id)
    {
        var details = await _unitOfWork.MessageRepository.GetSingleAsync(id, new MessageDetailsQuery());
        if(details is not null)
            return new SuccessResult<MessageDetails>(details);
        return new NotFoundResult<MessageDetails>("Not found.");
    }
}
