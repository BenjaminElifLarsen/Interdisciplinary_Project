using Domain.DL.Models.MessageModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Messages.Queries.GetAll;
public sealed class MessageListItem : BaseReadModel
{
    public int Id { get; private set; }
    public int LifeformId { get; private set; }
    public string Title { get; private set; }
    public string Text { get; private set; }

    public MessageListItem(int id, int lifeformId, string title, string text)
    {
        Id = id;
        LifeformId = lifeformId;
        Title = title;
        Text = text;
    }
}

internal sealed class MessageListQuery : BaseQuery<Message, MessageListItem>
{
    public override Expression<Func<Message, MessageListItem>> Map()
    {
        return e => new(e.Id, e.Eukaryote.EukaryoteEukaryoteId, e.Title, e.Title.Substring(0,40));
    }
}
