using Domain.AL.Services.Messages.Queries.GetAuthorDetails;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.NotFound;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Messages;
public partial class MessageService : IMessageService
{
    public async Task<Result<AutherDetailsForMessage>> AuthorForMessageAsync(int id)
    {
        var details = await _unitOfWork.MessageAuthorRepository.GetSingleAsync(id, new AutherDetailsForMessageQuery());
        if(details is null)
        {
            return new NotFoundResult<AutherDetailsForMessage>("Not found.");
        }
        return new SuccessResult<AutherDetailsForMessage>(details);
    }
}
