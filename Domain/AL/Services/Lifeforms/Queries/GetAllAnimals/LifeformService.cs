using Domain.AL.Services.Lifeforms.Queries.GetAllAnimals;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public async Task<Result<IEnumerable<AnimalListItem>>> GetAllAnimals()
    {
        var list = await _unitOfWork.AnimalRepository.AllAsync(new AnimalListQuery());
        return new SuccessResult<IEnumerable<AnimalListItem>>(list);
    }
}
