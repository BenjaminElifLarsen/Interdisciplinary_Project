using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.CQRS.Commands.Users;
using Shared.CQRS.Commands;

namespace Domain.AL.Handlers.Commands;
public interface IDomainCommandHandler : 
    ICommandHandler<PostMessage>,
    ICommandHandler<RecogniseAnimal>,
    ICommandHandler<RecognisePlant>,
    ICommandHandler<LikeMessage>,
    ICommandHandler<RegistrateUser>
{
}
