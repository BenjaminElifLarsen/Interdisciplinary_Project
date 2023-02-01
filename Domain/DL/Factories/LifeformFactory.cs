using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Models.LifeformModels;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Success;
using SharedImplementation.BinaryFlag;

namespace Domain.DL.Factories;
internal class LifeformFactory : ILifeformFactory
{
    public Result<Eukaryote> CreateLifeform(RecogniseLifeform creationData)
    {
        return creationData.GetType().Name switch
        {
            nameof(RecogniseAnimal) => CreateLifeform(creationData as RecogniseAnimal),
            nameof(RecognisePlant) => CreateLifeform(creationData as RecognisePlant),
            _ => throw new Exception("The dev forgot a command")
        };
    }

    private static Result<Eukaryote> CreateLifeform(RecogniseAnimal creationData)
    {
        BinaryFlag flag = new();
        //validate
        //create if no error
        //if error, convert
        //return
        if (flag)
        {
            Animalia entity = new(creationData.Species, creationData.MaxAmountOfOffspring, creationData.MinAmountOfOffspring, creationData.IsItABird);
            return new SuccessResult<Eukaryote>(entity);
        }
        throw new NotImplementedException();
    }

    private static Result<Eukaryote> CurreateLifeform(RecognisePlant creationData)
    {
        BinaryFlag flag = new();
        //validate
        //create if no error
        //if error, convert
        //return
        if (flag)
        {
            Plantae entity = new(creationData.Species, creationData.PossibleMaximumHeight);
            return new SuccessResult<Eukaryote>(entity);
        }
        throw new NotImplementedException();
    }
}
