using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Errors;
using Domain.DL.Models.LifeformModels;
using Domain.DL.Validation;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;
using SharedImplementation.BinaryFlag;

namespace Domain.DL.Factories;
public class LifeformFactory : ILifeformFactory
{
    private AnimalValidationData _animalValidationData;
    private PlantValidationData _plantValidationData;

    //internal LifeformFactory(AnimalValidationData animalValidationData = null, PlantValidationData plantValidationData = null)
    //{
    //    _animalValidationData = animalValidationData;
    //    _plantValidationData = plantValidationData;

    //}

    public void SetValidationData(AnimalValidationData validationData) => _animalValidationData = validationData;
    public void SetValidationData(PlantValidationData validationData) => _plantValidationData = validationData;

    public Result<Eukaryote> CreateLifeform(RecogniseLifeform creationData)
    {
        return creationData.GetType().Name switch
        {
            nameof(RecogniseAnimal) => CreateLifeform(creationData as RecogniseAnimal, _animalValidationData),
            nameof(RecognisePlant) => CreateLifeform(creationData as RecognisePlant, _plantValidationData),
            _ => throw new Exception("The dev forgot a command")
        };
    }

    private static Result<Eukaryote> CreateLifeform(RecogniseAnimal creationData, AnimalValidationData validationData)
    {
        BinaryFlag flag = new AnimalValidator(creationData, validationData).Validate();
        if (flag)
        {
            Animalia entity = new(creationData.Species, creationData.MaxAmountOfOffspring, creationData.MinAmountOfOffspring, creationData.IsItABird);
            return new SuccessResult<Eukaryote>(entity);
        }
        else
        {
            var errors = AnimalErrorConversion.Convert(flag);
            return new InvalidResult<Eukaryote>(errors);
        }
    }

    private static Result<Eukaryote> CreateLifeform(RecognisePlant creationData, PlantValidationData validationData)
    {
        BinaryFlag flag = new PlantValidator(creationData, validationData).Validate();
        if (flag)
        {
            Plantae entity = new(creationData.Species, creationData.PossibleMaximumHeight);
            return new SuccessResult<Eukaryote>(entity);
        }
        else
        {
            var errors = PlantErrorConversion.Convert(flag);
            return new InvalidResult<Eukaryote>(errors);
        }
    }
}
