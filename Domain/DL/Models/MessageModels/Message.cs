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

    public int Id => throw new NotImplementedException();


    private Message()
    { //for entity framework core

    }
}
