using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Validation.Animals;
using Domain.DL.Validation.Eukaryotes;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern.Composite.Extensions;
using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.AnimalErrors;

namespace Domain.DL.Validation;
internal sealed class AnimalValidator
{
	private readonly RecogniseAnimal _animal;
	private readonly AnimalValidationData _validationData;

	public AnimalValidator(RecogniseAnimal animal, AnimalValidationData validationData)
	{
		_animal = animal;
		_validationData = validationData;
	}

	public BinaryFlag Validate()
	{
		BinaryFlag flag = new();
		flag += new IsAnimalSpeciesSat().And(new IsAnimalSpeciesNotInUse(_validationData.Species)).IsSatisfiedBy(_animal) ? 0 : SpeciesInvalid;
		flag += new IsAnimalMaxOffspringSat().IsSatisfiedBy(_animal) ? 0 : MaximumOffspringInvalid;
		flag += new IsAnimalMinOffspringSat().IsSatisfiedBy(_animal) ? 0 : MinimumOffspringInvalid;
		flag += new IsAnimalOffspringCombinationValid().IsSatisfiedBy(_animal) ? 0 : OffspringCombinationInvalid;
		return flag;
	}

}

internal sealed class AnimalChangeValidator
{
	private readonly ChangeAnimalInformation _animal;
	private readonly AnimalChangeValidationData _validationData;
	public AnimalChangeValidator(ChangeAnimalInformation animal, AnimalChangeValidationData validationData)
	{
		_animal = animal;
		_validationData = validationData;
	}

	public BinaryFlag Validate()
	{
		BinaryFlag flag = new();
		flag += new IsEukaryoteSpeciesSat().And(new IsEukaryoteSpeciesNotInUse(_validationData.Species)).IsSatisfiedBy(_animal) ? 0 : SpeciesInvalid;
		flag += new IsAnimalMaxOffspringSat().IsSatisfiedBy(_animal) ? 0 : MaximumOffspringInvalid;
		flag += new IsAnimalMinOffspringSat().IsSatisfiedBy(_animal) ? 0 : MinimumOffspringInvalid;
		flag += new IsAnimalOffspringCombinationValid().IsSatisfiedBy((_animal, _validationData.CurrentInformation)) ? 0 : OffspringCombinationInvalid;
		return flag;
	}
}

public sealed class AnimalValidationData
{
    internal IEnumerable<LifeformSpecies> Species { get; private set; }

	internal AnimalValidationData(IEnumerable<LifeformSpecies> species)
	{
		Species = species;
	}

	public static AnimalValidationData CreateTestObject(IEnumerable<string> species)
	{
		return new(species.Select(x => new LifeformSpecies(x)));
	}
}

public sealed class AnimalChangeValidationData
{
	internal IEnumerable<LifeformSpecies> Species { get; private set; }
	internal AnimalOffspringInformation CurrentInformation { get; private set; }

	internal AnimalChangeValidationData(IEnumerable<LifeformSpecies> species, AnimalOffspringInformation currentInformation)
	{
		Species = species;
		CurrentInformation = currentInformation;
	}
}