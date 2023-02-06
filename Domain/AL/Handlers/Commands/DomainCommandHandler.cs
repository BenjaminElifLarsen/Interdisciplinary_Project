using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.CQRS.Commands.Users;
using Domain.DL.Errors;
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
        if (result is SuccessResult<Message>)
        {
            _unitOfWork.MessageRepository.AddMessage(result.Data);
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
        var entity = _unitOfWork.MessageRepository.GetForOperationAsync(command.MessageId).Result;
        if (entity is null)
        {
            return new InvalidNoDataResult();
        } //should check if the user exist
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
        Eukaryote lifeform = _unitOfWork.PlantRepository.GetForOperationAsync(command.Id).Result as Eukaryote ?? _unitOfWork.AnimalRepository.GetForOperationAsync(command.Id).Result;
        if(lifeform is null)
        {
            return new SuccessNoDataResult();
        }
        _unitOfWork.LifeformRepository.RemoveLifeform(lifeform);
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
