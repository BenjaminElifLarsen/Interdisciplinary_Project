using Domain.DL.Models.LifeformModels;
using Domain.DL.Models.UserModels;
using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public sealed class Message : IAggregateRoot<int>
{
    private int _id;
    private int _userId;
    private int _eukaryoteId;
    private ObservationTimeAndLocation _data;

    private Eukaryote _eukaryote;
    private User _user;
    private HashSet<Like> _likes;

    public int Id { get => _id; private set => _id = value; }
    public int UserId { get => _userId; private set => _userId = value; }
    public int EukaryoteId { get => _eukaryoteId; private set => _eukaryoteId = value; }
    public long Latitude { get => _data.Latitude; }
    public long Longtitude { get => _data.Longitude;}
    public DateTime ObservationMoment { get => _data.Time; }
    public Eukaryote Eukaryote { get => _eukaryote; private set => _eukaryote = value; } 
    public User User { get => _user; private set => _user = value; }
    public IEnumerable<Like> Likes => _likes;
    internal ObservationTimeAndLocation Data { get => _data; private set => _data = value; }

    private Message()
    { //for entity framework core

    }

    public Message(int userId, int eukaryoteId, ObservationTimeAndLocation data)
    {
        _userId = userId;
        _data = data;
        _eukaryoteId = eukaryoteId;
    }

    internal void AddLike(int userId)
    {
        if (!_likes.Any(x => x.GotSpecificUserID(userId)) && userId != _userId)
            _likes.Add(new(userId, _id));

    }

    internal void RemoveLike(int userId)
    {
        var foundLike = _likes.SingleOrDefault(x => x.GotSpecificUserID(userId));
        if (foundLike is not null)
            _likes.Remove(foundLike);
    }
}
