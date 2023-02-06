using Domain.AL.Services.Lifeforms.Queries.GetSinglePlant;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.NotFound;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public async Task<Result<PlantDetails>> GetPlant(int id)
    {
        var details = await _unitOfWork.PlantRepository.GetSingleAsync(id, new PlantDetailsQuery());
        if (details is null) return new NotFoundResult<PlantDetails>("Not found.");
        return new SuccessResult<PlantDetails>(details);
    }
}
