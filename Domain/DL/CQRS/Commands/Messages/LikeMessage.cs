using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Messages;
public sealed class LikeMessage : ICommand
{
    public int UserId { get; set; }
    public int MessageId { get; set; }

    public LikeMessage(int userId, int messageId)
    {
        UserId = userId;
        MessageId = messageId;
    }
}
