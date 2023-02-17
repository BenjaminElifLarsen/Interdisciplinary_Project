using Domain.DL.Models.LifeformModels.ValueObjects;

namespace Domain.DL.Models.LifeformModels;
public class Plantae : Eukaryote
{
    private double _maximumHeight;


    public double MaximumHeight { get => _maximumHeight; private set => _maximumHeight = value; }
    
    private Plantae()
    {

    }

    public Plantae(string name, double maxHeight) : base(name)
    {
        _maximumHeight = maxHeight;
    }

    internal void NewMaximumHeight(double maximumHeight)
    {
        _maximumHeight = maximumHeight;
    }
}
