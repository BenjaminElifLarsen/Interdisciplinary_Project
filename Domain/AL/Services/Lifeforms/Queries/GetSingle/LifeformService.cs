using Domain.AL.Services.Lifeforms.Queries.GetSingle;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.NotFound;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{

    public async Task<Result<LifeformDetails>> GetAsync(int id)
    {
        var entity = await _unitOfWork.LifeformRepository.GetSingleAsync(id, new LifeformDetailsQuery());
        if(entity is null)
        {
            return new NotFoundResult<LifeformDetails>("Not found.");
        }
        return new SuccessResult<LifeformDetails>(entity);
    }
}
