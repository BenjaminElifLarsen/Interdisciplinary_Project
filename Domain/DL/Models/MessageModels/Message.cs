using Domain.DL.Models.MessageModels.ValueObjects;
using Shared.DDD;
using System.Text;

namespace Domain.DL.Models.MessageModels;
public sealed class Message : IAggregateRoot<int> //could add soft delete to this model, just let the save check if a model is getting deleted, if it is set it to unmodfieid and then modify the soft delete value to true
{
    private int _id;
    private Eukaryote _eukaryote;
    private ObservationTimeAndLocation _data;
    private User _user;
    private string _text;
    private string _title;

    private HashSet<Like> _likes;

    public int Id { get => _id; private set => _id = value; }
    public double Latitude { get => _data.Latitude; }
    public double Longtitude { get => _data.Longitude;}
    public DateTime ObservationMoment { get => _data.Time; }
    public string Text { get => _text; private set => _text = value; }
    public string Title { get => _title; private set => _title = value; }
    public Eukaryote Eukaryote { get => _eukaryote; private set => _eukaryote = value; } 
    public User User { get => _user; private set => _user = value; }
    public IEnumerable<Like> Likes => _likes;
    public ObservationTimeAndLocation Data { get => _data; private set => _data = value; }

    private Message()
    { //for entity framework core

    }

    public Message(string title, string text, int userId, int eukaryoteId, ObservationTimeAndLocation data)
    {
        _user = new(userId);
        _data = data;
        _eukaryote = new(eukaryoteId);
        _title = title;
        _text = text;
    }

    internal void AddLike(int userId)
    {
        if(userId != _user.UserUserId)
            _likes.Add(new(userId, _id));
    }

    internal void RemoveLike(int userId) => _likes.Remove(new(userId, _id));

    internal string GetShortenText(int maxLength)
    {
        if (maxLength <= 0)
            return "";
        var shouldShorten = _text.Length > maxLength;
        StringBuilder sb = new();
        sb.Append(!shouldShorten ? _text : _text[..maxLength]);
        if(shouldShorten)
            sb.Append("...");
        return sb.ToString();
    }
}
