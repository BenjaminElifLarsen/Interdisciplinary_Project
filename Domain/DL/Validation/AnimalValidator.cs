using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.Validation.Animals;
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

public sealed class AnimalValidationData
{
    public IEnumerable<string> Species { get; private set; }

	public AnimalValidationData(IEnumerable<string> species)
	{
		Species = species;
	}
}
