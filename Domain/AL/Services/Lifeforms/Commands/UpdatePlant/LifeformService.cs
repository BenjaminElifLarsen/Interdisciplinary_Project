using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public async Task<Result> UpdatePlantAsync(ChangePlantInformation command)
    {
        return await Task.Run(() => _commandBus.Dispatch(command));
    }
}
