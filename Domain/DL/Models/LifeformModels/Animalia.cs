namespace Domain.DL.Models.LifeformModels;
public class Animalia : Eukaryote
{
	private byte _maximumOffspringsPerMating;
	private byte _minimumOffspringsPerMating; //consider better names as it is the amount of children the animal can get at ones
	private bool _isBird;

	private Animalia()
	{

	}

	public Animalia(string name, byte maxOffspringAmount, byte minOffspringAmount, bool isBird) : base(name)
	{
		_maximumOffspringsPerMating = maxOffspringAmount;
		_minimumOffspringsPerMating = minOffspringAmount;
		_isBird = isBird;
	}
}
