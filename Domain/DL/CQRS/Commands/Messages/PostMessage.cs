using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Messages;
public sealed class PostMessage : ICommand
{
    public int UserId { get; set; }
    public int EukaryoteId { get; set; }
    public DateTime Moment { get; set; }
    public double Latitude { get; set; }
    public double Longtitude { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public PostMessage()
    {

    }

    private PostMessage(int userId, int eukaryoteId, DateTime moment, double latitude, double longtitude, string title, string text)
    { //used for testing
        UserId = userId;
        EukaryoteId = eukaryoteId;
        Moment = moment;
        Latitude = latitude;
        Longtitude = longtitude;
        Title = title;
        Text = text;
    }

    public static PostMessage CreateTestObject(int userId, int eukaryoteId, DateTime moment, double latitude, double longtitude, string title, string text)
    {
        return new(userId, eukaryoteId, moment, latitude, longtitude, title, text);
    }
}
