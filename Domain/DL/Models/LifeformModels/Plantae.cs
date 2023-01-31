﻿namespace Domain.DL.Models.LifeformModels;
public class Plantae : Eukaryote
{
    private double _maximumHeight;


    private Plantae()
    {

    }

    public Plantae(string name, double maxHeight) : base(name)
    {
        _maximumHeight = maxHeight;
    }
}
