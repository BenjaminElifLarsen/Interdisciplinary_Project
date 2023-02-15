using Domain.DL.Factories;

namespace TestCases.Eukaryote.Recognise.Animal;

public class RecogniseAnima
{
    [Fact]
    public void SuccessRecogniseAnimalTest()
    {
        ILifeformFactory factory = new LifeformFactory();
        var request = Domain.DL.CQRS.Commands.Lifeforms.RecogniseAnimal.CreateTestObject(3, 1, true, "Rook");
        var species = new string[] { "Magpie", "Cormorant", "Fallow Deer" };
        var validationData = Domain.DL.Validation.AnimalValidationData.CreateTestObject(species);
        factory.SetValidationData(validationData);
    }
}
