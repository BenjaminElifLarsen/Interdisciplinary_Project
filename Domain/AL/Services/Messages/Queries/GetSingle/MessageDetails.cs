using Domain.DL.Models.MessageModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Messages.Queries.GetSingle;
public sealed class MessageDetails : BaseReadModel
{
    public int Likes { get; private set; }
    public int User { get; private set; }
    public int LifeformId { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set;}
    public string Title { get; private set; }
    public string Text { get; private set; }
    public DateTime Time { get; private set; }

    public MessageDetails(int likes, int user, int lifeformId, double latitude, double longitude, DateTime time, string title, string text)
    {
        Likes = likes;
        User = user;
        LifeformId = lifeformId;
        Latitude = latitude;
        Longitude = longitude;
        Time = time;
        Title = title;
        Text = text;
    }
}

internal sealed class MessageDetailsQuery : BaseQuery<Message, MessageDetails>
{
    public override Expression<Func<Message, MessageDetails>> Map()
    {
        return e => new(e.Likes.Count(), e.User.UserUserId, e.Eukaryote.EukaryoteEukaryoteId, e.Latitude, e.Longtitude, e.ObservationMoment, e.Title, e.Text);
    }
}
