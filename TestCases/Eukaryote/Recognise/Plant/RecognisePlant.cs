using Domain.DL.Factories;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;

namespace TestCases.Eukaryote.Recognise.Plant;

public class RecognisePlant
{
    [Fact]
    public void SuccessRecognisePlantTest()
    {
        ILifeformFactory factory = new LifeformFactory();
        var request = Domain.DL.CQRS.Commands.Lifeforms.RecognisePlant.CreateTestObject(12.2, "Carica Papaya");
        var species = new string[] { "Cucumis Melo" };
        var validationData = Domain.DL.Validation.PlantValidationData.CreateTestObject(species);
        factory.SetValidationData(validationData);
        var result = factory.CreateLifeform(request);
        Assert.True(result is SuccessResult<Domain.DL.Models.LifeformModels.Eukaryote>);
    }

    [Fact]
    public void FailedOnSpeciesRecognisePlantTest()
    {
        ILifeformFactory factory = new LifeformFactory();
        var request = Domain.DL.CQRS.Commands.Lifeforms.RecognisePlant.CreateTestObject(12.2, "Carica Papaya".ToLower());
        var species = new string[] { "Cucumis Melo", "Carica Papaya" };
        var validationData = Domain.DL.Validation.PlantValidationData.CreateTestObject(species);
        factory.SetValidationData(validationData);
        var result = factory.CreateLifeform(request);
        Assert.True(result is InvalidResult<Domain.DL.Models.LifeformModels.Eukaryote>);
    }

    [Fact]
    public void FailedOnHeightRecognisePlantTest()
    {
        ILifeformFactory factory = new LifeformFactory();
        var request = Domain.DL.CQRS.Commands.Lifeforms.RecognisePlant.CreateTestObject(0, "Carica Papaya".ToLower());
        var species = new string[] { "Cucumis Melo" };
        var validationData = Domain.DL.Validation.PlantValidationData.CreateTestObject(species);
        factory.SetValidationData(validationData);
        var result = factory.CreateLifeform(request);
        Assert.True(result is InvalidResult<Domain.DL.Models.LifeformModels.Eukaryote>);
    }


}
