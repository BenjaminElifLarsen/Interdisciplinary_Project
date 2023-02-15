using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Lifeforms;
public abstract class RecogniseLifeform : ICommand
{
    public string Species { get; set; }

    public RecogniseLifeform()
    {

    }

    internal RecogniseLifeform(string species)
    {
        Species = species;
    }
}

public sealed class RecogniseAnimal : RecogniseLifeform
{
    public byte MaxAmountOfOffspring { get; set; }
    public byte MinAmountOfOffspring { get; set; }
    public bool IsItABird { get; set; }

    public RecogniseAnimal()
    {

    }

    internal RecogniseAnimal(byte maxOffspring, byte minOffspring, bool isBird, string species) : base(species)
    {
        MaxAmountOfOffspring = maxOffspring;
        MinAmountOfOffspring = minOffspring;
        IsItABird = isBird;
    }

    public static RecogniseAnimal CreateTestObject(byte maxOffspring, byte minOffspring, bool isBird, string species)
    {
        return new(maxOffspring, minOffspring, isBird, species);
    }
}

public sealed class RecognisePlant : RecogniseLifeform
{
    public double PossibleMaximumHeight { get; set; }

    public RecognisePlant()
    {

    }

    internal RecognisePlant(double possibleMaximumHeight, string species) : base(species)
    {
        PossibleMaximumHeight = possibleMaximumHeight;
    }

    public static RecognisePlant CreateTestObject(double possibleMaximumHeight, string species)
    {
        return new(possibleMaximumHeight, species);
    }
}