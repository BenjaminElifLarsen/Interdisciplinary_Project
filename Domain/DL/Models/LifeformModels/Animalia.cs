using Domain.DL.Models.LifeformModels.ValueObjects;

namespace Domain.DL.Models.LifeformModels;
public sealed class Animalia : Eukaryote
{
	private byte _maximumOffspringsPerMating;
	private byte _minimumOffspringsPerMating; //consider better names as it is the amount of children the animal can get at ones
	private bool _isBird;

    private HashSet<AnimalMessage> _messages;
    public IEnumerable<AnimalMessage> Messages => _messages;

    public byte MaximumOffspringsPerMating { get => _maximumOffspringsPerMating; private set => _maximumOffspringsPerMating = value; }
	public byte MinimumOffspringsPerMating { get => _minimumOffspringsPerMating; private set => _minimumOffspringsPerMating = value; }
	public bool IsBird { get => _isBird; private set => _isBird = value;  }
    public override bool BeenObservered => _messages.Any();

    private Animalia()
	{

	}

	public Animalia(string name, byte maxOffspringAmount, byte minOffspringAmount, bool isBird) : base(name)
	{
		_maximumOffspringsPerMating = maxOffspringAmount;
		_minimumOffspringsPerMating = minOffspringAmount;
		_isBird = isBird;
	}

	internal override void AddMessage(int messageId)
	{
		_messages.Add(new(messageId));
	}

	internal override void RemoveMessage(int messageId)
	{
		_messages.Remove(new(messageId));
	}

	internal void ChangeBirdStatus(bool isBird)
	{
		_isBird = isBird;
	}

	internal void AlterMaximumOffspringPerMating(byte maximumOffspringAmount)
	{
		_maximumOffspringsPerMating = maximumOffspringAmount;
	}

	internal void AlterMinimumOffspringPerMating(byte minimumOffspringAmount)
	{
		_minimumOffspringsPerMating = minimumOffspringAmount;
	}
}
