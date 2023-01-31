using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Models.LifeformModels;
using Shared.ResultPattern.Abstract;

namespace Domain.DL.Factories;
internal class LifeformFactory : ILifeformFactory
{
    public Result<Eukaryote> CreateLifeform(RecogniseLifeform creationData)
    {
        switch (creationData.GetType().Name)
        {
            case nameof(RecogniseAnimal):
                return CreateLifeform(creationData as RecogniseAnimal);
                break;

            case nameof(RecognisePlant):
                return CreateLifeform(creationData as RecognisePlant);
                //check if factory returns result in the other project
            default: break;
        }
        throw new NotImplementedException();
    }

    private Result<Eukaryote> CreateLifeform(RecogniseAnimal creationData)
    {
        throw new NotImplementedException();
    }

    private Result<Eukaryote> CurreateLifeform(RecognisePlant creationData)
    {
        throw new NotImplementedException();
    }
}
