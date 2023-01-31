using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public class Message : IAggregateRoot<int>
{
    public int Id => throw new NotImplementedException();
}
