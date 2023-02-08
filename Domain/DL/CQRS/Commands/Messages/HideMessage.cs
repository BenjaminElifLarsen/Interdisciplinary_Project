using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Messages;
public sealed class HideMessage : ICommand
{
    public int MessageId { get; set; }
}
