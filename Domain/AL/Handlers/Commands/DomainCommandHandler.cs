using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Factories;
using Domain.IPL.Services;

namespace Domain.AL.Handlers.Commands;
internal sealed class DomainCommandHandler : IDomainCommandHandler
{
    //need factories and unit of work
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageFactory _messageFactory;
    private readonly IUserFactory _userFactory;
    private readonly ILifeformFactory _lifeformFactory;

    public DomainCommandHandler(IUnitOfWork unitOfWork, IMessageFactory messageFactory, IUserFactory userFactory, ILifeformFactory lifeformFactory)
    {
        _unitOfWork = unitOfWork;
        _messageFactory = messageFactory;
        _userFactory = userFactory;
        _lifeformFactory = lifeformFactory;
    }

    public void Handle(InsertMessage command)
    { //needd validation data
        var result = _messageFactory.CreateMessage(command);
        throw new NotImplementedException();
    }

    public void Handle(RecogniseLifeform command)
    {
        throw new NotImplementedException();
    }

    public void Handle(LikeMessage command)
    {
        throw new NotImplementedException();
    }

    public void Handle(RegistrateUser command)
    {
        throw new NotImplementedException();
    }
}
