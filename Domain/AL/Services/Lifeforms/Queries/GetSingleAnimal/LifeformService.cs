using Domain.AL.Services.Lifeforms.Queries.GetSingleAnimal;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.NotFound;
using Shared.ResultPattern.Success;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public async Task<Result<AnimalDetails>> GetAnimal(int id)
    {
        var details = await _unitOfWork.AnimalRepository.GetSingleAsync(id, new AnimalDetailsQuery());
        if (details is null) return new NotFoundResult<AnimalDetails>("Not found.");
        return new SuccessResult<AnimalDetails>(details);
    }
}
