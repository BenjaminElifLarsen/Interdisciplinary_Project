using Domain.DL.Models.LifeformModels;
using Domain.DL.Models.UserModels;
using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public class Message : IAggregateRoot<int>
{
    private int _id;
    private int _userId;
    private int _eukaryoteId;
    private DateTime _observationMoment;
    private long _latitude;
    private long _longitude;

    private Eukaryote _eukaryote;
    private User _user;

    public int Id { get => _id; private set => _id = value; }
    public int UserId { get => _userId; private set => _userId = value; }
    public int EukaryoteId { get => _eukaryoteId; private set => _eukaryoteId = value; }
    public long Latitude { get => _latitude; private set => _latitude = value; }
    public long Longtitude { get => _longitude; private set => _longitude = value; }
    public DateTime ObservationMoment { get => _observationMoment; private set => _observationMoment = value; }
    public Eukaryote Eukaryote { get => _eukaryote; private set => _eukaryote = value; } 
    public User User { get => _user; private set => _user = value; }

    private Message()
    { //for entity framework core

    }
}
