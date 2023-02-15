using Domain.DL.Models.MessageModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Messages.Queries.GetSingle;
public sealed class MessageDetails : BaseReadModel
{
    public int Likes { get; private set; }
    public int Author { get; private set; }
    public int LifeformId { get; private set; }
    public double Latitude { get; private set; }
    public double Longtitude { get; private set;}
    public string Title { get; private set; }
    public string Text { get; private set; }
    public DateTime Time { get; private set; }

    public MessageDetails(int likes, int author, int lifeformId, double latitude, double longtitude, DateTime time, string title, string text)
    {
        Likes = likes;
        Author = author;
        LifeformId = lifeformId;
        Latitude = latitude;
        Longtitude = longtitude;
        Time = time;
        Title = title;
        Text = text;
    }
}

internal sealed class MessageDetailsQuery : BaseQuery<Message, MessageDetails>
{
    public override Expression<Func<Message, MessageDetails>> Map()
    {
        return e => new(e.Likes.Count(), e.Author.AuthorUserId, e.Eukaryote.EukaryoteEukaryoteId, e.Latitude, e.Longtitude, e.ObservationMoment, e.Title, e.Text);
    }
}
