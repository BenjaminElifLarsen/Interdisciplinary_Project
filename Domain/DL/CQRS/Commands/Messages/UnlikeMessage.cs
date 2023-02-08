using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Messages;
public sealed class UnlikeMessage : ICommand
{
    public int UserId { get; set; }
    public int MessageId { get; set; }
}
