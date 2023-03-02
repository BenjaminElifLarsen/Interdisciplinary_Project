using Domain.AL.Services.Lifeforms.Queries.GetSingle;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public async Task<Result<IEnumerable<LifeformDetails>>> AllAsync()
    {
        var list = await _unitOfWork.LifeformRepository.AllAsync(new LifeformDetailsQuery());
        return new SuccessResult<IEnumerable<LifeformDetails>>(list);
    }
}
