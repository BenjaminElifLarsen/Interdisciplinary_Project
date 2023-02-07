using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Errors;
using Domain.DL.Factories;
using Domain.DL.Models.LifeformModels;
using Domain.DL.Models.MessageModels;
using Domain.DL.Models.MessageModels.ValueObjects;
using Domain.DL.Models.UserModels;
using Domain.DL.Validation;
using Domain.DL.Validation.ReadModels;
using Domain.IPL.Services;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;
using Eukaryote = Domain.DL.Models.LifeformModels.Eukaryote;
using User = Domain.DL.Models.UserModels.User;

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
        if (result is SuccessResult<Message>)
        {
            _unitOfWork.MessageRepository.AddMessage(result.Data);
            _unitOfWork.Save();

            var entityUser = _unitOfWork.UserRepository.GetForOperationAsync(command.UserId).Result;
            var entityEukaryote = _unitOfWork.PlantRepository.GetForOperationAsync(command.EukaryoteId).Result as Eukaryote ?? _unitOfWork.AnimalRepository.GetForOperationAsync(command.EukaryoteId).Result;

            entityUser.AddMessage(result.Data.Id);
            entityEukaryote.AddMessage(result.Data.Id);
            _unitOfWork.UserRepository.UpdateUser(entityUser);
            _unitOfWork.LifeformRepository.UpdateLifeform(entityEukaryote);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }

    public Result Handle(RecogniseLifeform command) //is never called, need to handle for the sub versions
    {
        Result<Eukaryote>? result = default;
        if (command is RecogniseAnimal)
        {
            var animalSpecies = _unitOfWork.AnimalRepository.AllAsync(new AnimalSpeciesQuery()).Result;
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
        if (result is SuccessResult<Eukaryote>)
        {
            _unitOfWork.LifeformRepository.AddLifeform(result.Data);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }

    public Result Handle(LikeMessage command)
    {
        var entityMessage = _unitOfWork.MessageRepository.GetForOperationAsync(command.MessageId).Result;
        if (entityMessage is null)
        {
            return new InvalidNoDataResult("Message not found.");
        } //need to add to the message and to the user who made the like
        var entityUser = _unitOfWork.UserRepository.GetForOperationAsync(command.UserId).Result;
        if(entityUser is null)
        {
            return new InvalidNoDataResult("User not founbd.");
        }
        entityMessage.AddLike(command.UserId);
        entityUser.AddLike(command.MessageId);
        _unitOfWork.MessageRepository.UpdateMessage(entityMessage);
        _unitOfWork.UserRepository.UpdateUser(entityUser);
        _unitOfWork.Save();
        return new SuccessNoDataResult();
    }

    public Result Handle(RegistrateUser command)
    {
        var usernames = _unitOfWork.UserRepository.AllAsync(new UserUsernameQuery()).Result;
        UserValidationData validationData = new(usernames);
        var result = _userFactory.CreateUser(command, validationData);
        if (result is SuccessResult<User>)
        {
            _unitOfWork.UserRepository.AddUser(result.Data);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }

    public Result Handle(RecogniseAnimal command)
    {
        var animalSpecies = _unitOfWork.AnimalRepository.AllAsync(new AnimalSpeciesQuery()).Result;
        AnimalValidationData validationData = new(animalSpecies);
        _lifeformFactory.SetValidationData(validationData);
        Result<Eukaryote> result = _lifeformFactory.CreateLifeform(command);
        if (result is SuccessResult<Eukaryote>)
        {
            _unitOfWork.LifeformRepository.AddLifeform(result.Data);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }

    public Result Handle(RecognisePlant command)
    {
        var plantSpecies = _unitOfWork.PlantRepository.AllAsync(new PlantSpeciesQuery()).Result;
        PlantValidationData validationData = new(plantSpecies);
        _lifeformFactory.SetValidationData(validationData);
        Result<Eukaryote> result = _lifeformFactory.CreateLifeform(command);
        if (result is SuccessResult<Eukaryote>)
        {
            _unitOfWork.LifeformRepository.AddLifeform(result.Data);
            _unitOfWork.Save();
            return new SuccessNoDataResult();
        }
        return new InvalidNoDataResult(result.Errors);
    }

    public Result Handle(UnreogniseLifeform command)
    {
        Eukaryote entity = _unitOfWork.PlantRepository.GetForOperationAsync(command.Id).Result as Eukaryote ?? _unitOfWork.AnimalRepository.GetForOperationAsync(command.Id).Result;
        if(entity is null)
        {
            return new SuccessNoDataResult();
        }
        //if Eukaryote message count is not zero it should be unable to remove it.
        _unitOfWork.LifeformRepository.RemoveLifeform(entity);
        _unitOfWork.Save();
        return new SuccessNoDataResult();
    }

    public Result Handle(ChangeAnimalInformation command)
    {
        var entity = _unitOfWork.AnimalRepository.GetForOperationAsync(command.Id).Result;
        if (entity is null) return new InvalidNoDataResult("Not found.");
        var species = _unitOfWork.AnimalRepository.AllAsync(new AnimalSpeciesQuery()).Result;
        var entityInformation = _unitOfWork.AnimalRepository.GetSingleAsync(command.Id, new AnimalOffspringInformationQuery()).Result;
        AnimalChangeValidationData data = new(species, entityInformation);
        var flag = new AnimalChangeValidator(command, data).Validate();
        if (!flag)
        {
            return new InvalidNoDataResult(AnimalErrorConversion.Convert(flag));
        }
        if (command.IsBird is not null) entity.ChangeBirdStatus(command.IsBird.IsBird);
        if (command.Species is not null) entity.ChangeSpecies(command.Species.Species);
        if (command.MaximumOffspring is not null) entity.AlterMaximumOffspringPerMating(command.MaximumOffspring.MaximumOffspring);
        if (command.MinimumOffspring is not null) entity.AlterMinimumOffspringPerMating(command.MinimumOffspring.MinimumOffspring);
        _unitOfWork.LifeformRepository.UpdateLifeform(entity);
        _unitOfWork.Save();
        return new SuccessNoDataResult();
    }

    public Result Handle(ChangePlantInformation command)
    {
        var entity = _unitOfWork.PlantRepository.GetForOperationAsync(command.Id).Result;
        if (entity is null) return new InvalidNoDataResult("Not found.");
        var species = _unitOfWork.PlantRepository.AllAsync(new PlantSpeciesQuery()).Result;
        PlantChangeValidationData data = new(species);
        var flag = new PlantChangeValidator(command, data).Validate();
        if (!flag)
        {
            return new InvalidNoDataResult(PlantErrorConversion.Convert(flag));
        }
        if (command.Species is not null) entity.ChangeSpecies(command.Species.Species);
        if (command.MaximumHeight is not null) entity.NewMaximumHeight(command.MaximumHeight.MaximumHeight);
        _unitOfWork.LifeformRepository.UpdateLifeform(entity);
        _unitOfWork.Save();
        return new SuccessNoDataResult();
    }
}
