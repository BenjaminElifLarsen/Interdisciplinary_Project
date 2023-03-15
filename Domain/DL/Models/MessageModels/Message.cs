using Domain.DL.Models.MessageModels.ValueObjects;
using Shared.DDD;
using System.Text;

namespace Domain.DL.Models.MessageModels;
public sealed class Message : IAggregateRoot<int>//could add soft delete to this model, just let the save check if a model is getting deleted, if it is set it to unmodfieid and then modify the soft delete value to true
{
    private int _id;
    private Lifeform _eukaryote;
    private int _eukaryoteId;
    private ObservationTimeAndLocation _data;
    private Author _author;
    private int _authorId;
    private string _text;
    private string _title;

    private HashSet<MessageLike> _likes;

    public int Id { get => _id; private set => _id = value; }
    public double Latitude { get => _data.Latitude; }
    public double Longtitude { get => _data.Longitude;}
    public DateTime ObservationMoment { get => _data.Time; }
    public string Text { get => _text; private set => _text = value; }
    public string Title { get => _title; private set => _title = value; }
    public Lifeform Eukaryote { get => _eukaryote; private set => _eukaryote = value; } 
    public int EukaryoteId { get => _eukaryoteId; private set => _eukaryoteId = value; }
    public Author Author { get => _author; private set => _author = value; }
    public int AuthorId { get => _authorId; private set => _authorId = value; }
    public IEnumerable<MessageLike> Likes => _likes;
    public ObservationTimeAndLocation Data { get => _data; private set => _data = value; }

    private Message()
    { //for entity framework core

    }

    public Message(string title, string text, int authorId, int eukaryoteId, ObservationTimeAndLocation data)
    {
        _authorId = authorId;
        _data = data;
        _eukaryote = new(eukaryoteId);
        _title = title;
        _text = text;
        _likes = new();
    }

    public void AddLike(int userId)
    {
        if(userId != _authorId && !_likes.Any(x => x.UserId == userId))
            _likes.Add(new(userId, _id));
    }

    public void RemoveLike(int userId) => _likes.Remove(new(userId, _id));

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

    public void SetTestId(int id)
    {
        _id = id;
    }
}
