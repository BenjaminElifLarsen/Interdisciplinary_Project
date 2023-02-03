using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Factories;
using Domain.DL.Models.LifeformModels;
using Domain.DL.Models.MessageModels;
using Domain.DL.Models.UserModels;
using Domain.DL.Validation;
using Domain.DL.Validation.ReadModels;
using Domain.IPL.Services;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;

namespace Domain.AL.Handlers.Commands;
public sealed class DomainCommandHandler : IDomainCommandHandler
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

    public Result Handle(PostMessage command)
    { 
        var userIds = _unitOfWork.UserRepository.AllAsync(new UserIdQuery()).Result;
        var animalIds = _unitOfWork.AnimalRepository.AllAsync(new AnimalIdQuery()).Result;
        var plantIds = _unitOfWork.PlantRepository.AllAsync(new PlantIdQuery()).Result;
        MessageValidationData validationData = new(userIds, animalIds.Concat(plantIds));
        var result = _messageFactory.CreateMessage(command, validationData);
        if(result is SuccessResult<Message>)
        {
            _unitOfWork.MessageRepository.AddMessage(result.Data);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }

    public Result Handle(RecogniseLifeform command)
    {
        Result<Eukaryote>? result = default;
        if(command is RecogniseAnimal)
        {
            var animalSpecies = _unitOfWork.AnimalRepository.AllAsync(new AnimnalSpeciesQuery()).Result;
            AnimalValidationData validationData = new(animalSpecies);
            _lifeformFactory.SetValidationData(validationData);
            result = _lifeformFactory.CreateLifeform(command);
        }
        else
        {
            var plantSpecies = _unitOfWork.PlantRepository.AllAsync(new PlantSpeciesQuery()).Result;
            PlantValidationData validationData = new(plantSpecies);
            _lifeformFactory.SetValidationData(validationData);
            result = _lifeformFactory.CreateLifeform(command);
        }
        if(result is SuccessResult<Eukaryote>)
        {
            _unitOfWork.LifeformRepository.AddLifeform(result.Data);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }

    public Result Handle(LikeMessage command)
    {
        var entity = _unitOfWork.MessageRepository.GetForOperationAsync(command.MessageId).Result;
        if(entity is null) 
        {
            return new InvalidNoDataResult();
        }
        entity.AddLike(command.UserId);
        _unitOfWork.MessageRepository.UpdateMessage(entity);
        _unitOfWork.Save();
        return new SuccessNoDataResult();
    }

    public Result Handle(RegistrateUser command)
    {
        var usernames = _unitOfWork.UserRepository.AllAsync(new UserUsernameQuery()).Result;
        UserValidationData validationData = new(usernames);
        var result = _userFactory.CreateUser(command, validationData);
        if(result is SuccessResult<User>)
        {
            _unitOfWork.UserRepository.AddUser(result.Data);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }
}
