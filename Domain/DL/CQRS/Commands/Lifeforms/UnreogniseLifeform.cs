using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Lifeforms;
public class UnreogniseLifeform : ICommand
{ //no reason to do a split here
    //should not be able to remove a lifeform with observations, some business logic 
    public int Id { get; set; } //need to call the lifeform repository
}
