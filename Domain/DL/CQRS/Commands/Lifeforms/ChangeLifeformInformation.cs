using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Lifeforms;

public class ChangeLifeformInformation : ICommand //remember to validate these commands first before updating
{
    public ChangeSpecies? Species { get; set; }
}

public class ChangeSpecies
{
    public string Species { get; set; }
}

public class ChangeAnimalInformation : ChangeLifeformInformation
{
    public ChangeIsBird IsBird { get; set; }
    public ChangeMaximumOffspring MaximumOffspring { get; set; }
    public ChangeMinimumOffspring MinimumOffspring { get; set; }
}

public class ChangeIsBird
{
    public bool IsBird { get; set;}
}

public class ChangeMaximumOffspring
{
    public byte MaximumOffspring { get; set;}
}

public class ChangeMinimumOffspring
{
    public byte MinimumOffspring { get; set; }
}


public class ChangePlantInformation : ChangeLifeformInformation 
{ 
    public ChangeMaximumHeight MaximumHeight { get; set; }
}

public class ChangeMaximumHeight
{
    public double MaximumHeight { get; set; }
}