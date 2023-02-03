using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public Task<Result> RecogniseAnimal(RecogniseAnimal command)
    { //base upon the Old non-event code, would require changing the command bus to return a result
        return Task.Run(() => _commandBus.Dispatch(command));
    }
}
