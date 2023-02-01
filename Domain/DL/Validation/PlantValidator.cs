using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Validation.Plants;
using Shared.SpecificationPattern.Composite.Extensions;
using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.PlantErrors;

namespace Domain.DL.Validation;
internal sealed class PlantValidator 
{
	private readonly RecognisePlant _plant;
	private readonly PlantValidationData _validationData;

	public PlantValidator(RecognisePlant plant, PlantValidationData validationData)
	{
		_plant = plant;
		_validationData = validationData;
	}

	public BinaryFlag Validate()
	{
		BinaryFlag flag = new();
		flag += new IsPlantSpeciesSat().And(new IsPlantSpeciesNotInUse(_validationData.Species)).IsSatisfiedBy(_plant) ? 0 : SpeciesInvalid;
		flag += new IsPlantMaximumHeightValid().IsSatisfiedBy(_plant) ? 0 : MaximumHeightInvalid;
		return flag;
	}
}




internal sealed class PlantValidationData
{
    public IEnumerable<string> Species { get; set; }

	public PlantValidationData(IEnumerable<string> species)
	{
		Species = species;
	}
}