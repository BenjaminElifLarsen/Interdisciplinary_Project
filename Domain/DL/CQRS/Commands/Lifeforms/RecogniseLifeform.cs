using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Lifeforms;
public abstract class RecogniseLifeform : ICommand
{
    public string Species { get; set; }
}

public sealed class RecogniseAnimal : RecogniseLifeform
{
    public byte MaxAmountOfOffspring { get; set; }
    public byte MinAmountOfOffspring { get; set; }
    public bool IsItABird { get; set; }
}

public sealed class RecognisePlant : RecogniseLifeform
{
    public double PossibleMaximumHeight { get; set; }
}