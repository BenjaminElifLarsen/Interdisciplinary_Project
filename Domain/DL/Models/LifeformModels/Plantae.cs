using Domain.DL.Models.LifeformModels.ValueObjects;

namespace Domain.DL.Models.LifeformModels;
public class Plantae : Eukaryote
{
    private double _maximumHeight;

    private HashSet<PlantMessage> _messages;
    public IEnumerable<PlantMessage> Messages => _messages;


    public double MaximumHeight { get => _maximumHeight; private set => _maximumHeight = value; }
    public override bool BeenObservered => _messages.Any();

    private Plantae()
    {

    }

    public Plantae(string name, double maxHeight) : base(name)
    {
        _maximumHeight = maxHeight;
    }

    internal override void AddMessage(int messageId)
    {
        _messages.Add(new(messageId));
    }

    internal override void RemoveMessage(int messageId)
    {
        _messages.Remove(_messages.SingleOrDefault(x => x.MessageMessageId == messageId));
    }

    internal void NewMaximumHeight(double maximumHeight)
    {
        _maximumHeight = maximumHeight;
    }
}
