using Shared.DDD;

namespace Domain.DL.Models.MessageModels.ValueObjects;
public sealed record ObservationTimeAndLocation : ValueObject
{
    private DateTime _time;
    private long _latitude;
    private long _longitude;

    public DateTime Time { get => _time; private set => _time = value; }
    public long Latitude { get => _latitude; private set => _latitude = value; }
    public long Longitude { get => _longitude; private set => _longitude = value; }

    private ObservationTimeAndLocation()
    {

    }

    public ObservationTimeAndLocation(DateTime time, long latitude, long longitude)
    {
        _time = time;
        _latitude = latitude;
        _longitude = longitude;
    }
}
