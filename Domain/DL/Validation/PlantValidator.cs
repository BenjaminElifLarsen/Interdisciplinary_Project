using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Validation.Eukaryotes;
using Domain.DL.Validation.Plants;
using Domain.DL.Validation.ReadModels;
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

internal sealed class PlantChangeValidator
{
	private readonly ChangePlantInformation _plant;
	private readonly PlantChangeValidationData _validationData;

	public PlantChangeValidator(ChangePlantInformation plant, PlantChangeValidationData validationData)
	{
		_plant = plant;
		_validationData = validationData;
	}

	public BinaryFlag Validate()
	{
		BinaryFlag flag = new();
		flag += new IsEukaryoteSpeciesSat().And(new IsEukaryoteSpeciesNotInUse(_validationData.Species)).IsSatisfiedBy(_plant) ? 0 : SpeciesInvalid;
		flag += new IsPlantMaximumHeightValid().IsSatisfiedBy(_plant) ? 0 : MaximumHeightInvalid;
		return flag;
	}
}

public sealed class PlantValidationData
{
    internal IEnumerable<LifeformSpecies> Species { get; private set; }

	internal PlantValidationData(IEnumerable<LifeformSpecies> species)
	{
		Species = species;
	}
}

public sealed class PlantChangeValidationData
{
	internal IEnumerable<LifeformSpecies> Species { get; private set; }

	internal PlantChangeValidationData(IEnumerable<LifeformSpecies> species)
	{

	}
}