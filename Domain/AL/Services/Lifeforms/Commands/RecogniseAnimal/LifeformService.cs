using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public Task<Result> RecogniseAnimal(RecogniseAnimal command)
    { //base upon the Old non-event code
        throw new NotImplementedException();
    }
}
