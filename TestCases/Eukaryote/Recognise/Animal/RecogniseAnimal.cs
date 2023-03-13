using Domain.DL.Factories;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;

namespace TestCases.Eukaryote.Recognise.Animal;

public class RecogniseAnimal
{
    [Fact]
    public void SuccessRecogniseAnimalTest()
    {
        ILifeformFactory factory = new LifeformFactory();
        var request = Domain.DL.CQRS.Commands.Lifeforms.RecogniseAnimal.CreateTestObject(3, 1, true, "Rook");
        var species = new string[] { "Magpie", "Cormorant", "Fallow Deer" };
        var validationData = Domain.DL.Validation.AnimalValidationData.CreateTestObject(species);
        factory.SetValidationData(validationData);
        var result = factory.CreateLifeform(request);
        Assert.True(result is SuccessResult<Domain.DL.Models.LifeformModels.Eukaryote>);
    }

    [Fact]
    public void FailedOnSpeciesRecogniseAnimalTest()
    {
        ILifeformFactory factory = new LifeformFactory();
        var request = Domain.DL.CQRS.Commands.Lifeforms.RecogniseAnimal.CreateTestObject(3, 1, true, "rook");
        var species = new string[] { "Magpie", "Cormorant", "Fallow Deer", "Rook" };
        var validationData = Domain.DL.Validation.AnimalValidationData.CreateTestObject(species);
        factory.SetValidationData(validationData);
        var result = factory.CreateLifeform(request);
        Assert.True(result is InvalidResult<Domain.DL.Models.LifeformModels.Eukaryote>);
    }

    [Fact]
    public void FailedOnOffspringRecogniseAnimalTest()
    {
        ILifeformFactory factory = new LifeformFactory();
        var request = Domain.DL.CQRS.Commands.Lifeforms.RecogniseAnimal.CreateTestObject(0, 1, true, "Rook");
        var species = new string[] { "Magpie", "Cormorant", "Fallow Deer" };
        var validationData = Domain.DL.Validation.AnimalValidationData.CreateTestObject(species);
        factory.SetValidationData(validationData);
        var result = factory.CreateLifeform(request);
        Assert.True(result is InvalidResult<Domain.DL.Models.LifeformModels.Eukaryote>);
    }
}
