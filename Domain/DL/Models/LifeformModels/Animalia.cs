namespace Domain.DL.Models.LifeformModels;
public class Animalia : Eukaryote
{
	private byte _maximumOffspringsPerMating;
	private byte _minimumOffspringsPerMating; //consider better names as it is the amount of children the animal can get at ones

	private Animalia()
	{

	}

	public Animalia(string name) : base(name)
	{

	}
}
