using Domain.AL.Services.Lifeforms.Queries.GetAllPlants;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public async Task<Result<IEnumerable<PlantListItem>>> GetAllPlants()
    {
        var list = await _unitOfWork.PlantRepository.AllAsync(new PlantListItemQuery());
        return new SuccessResult<IEnumerable<PlantListItem>>(list);
    }
}
