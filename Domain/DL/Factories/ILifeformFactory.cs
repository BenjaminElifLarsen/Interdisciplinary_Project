using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Models.LifeformModels;
using Domain.DL.Validation;
using Shared.ResultPattern.Abstract;

namespace Domain.DL.Factories;
public interface ILifeformFactory
{
    public void SetValidationData(AnimalValidationData validationData);
    public void SetValidationData(PlantValidationData validationData);
    public Result<Eukaryote> CreateLifeform(RecogniseLifeform creationData);
}
