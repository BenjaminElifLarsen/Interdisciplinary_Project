using Shared.DDD;

namespace Domain.DL.Models.UserModels;
public class User : IAggregateRoot<int>
{
    public int Id => throw new NotImplementedException();
}
