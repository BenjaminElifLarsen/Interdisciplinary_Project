using Domain.DL.Models.MessageModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Messages.Queries.GetOwn;
public sealed class OwnMessageListItem : BaseReadModel
{
    public int Id { get; private set; }
    public int Likes { get; private set; }

    public OwnMessageListItem(int id, int likes)
    {
        Id = id;
        Likes = likes;
    }
}

internal sealed class OwnMessageListQuery : BaseQuery<Message, OwnMessageListItem>
{
    public override Expression<Func<Message, OwnMessageListItem>> Map()
    {
        return e => new(e.Id, e.Likes.Count());
    }
}