using Shared.DDD;

namespace Domain.DL.Models.MessageModels;
public sealed record ObservationTimeAndLocation : ValueObject
{
    private readonly DateTime _time;
    private readonly long _latitude;
    private readonly long _longitude;

    internal DateTime Time => _time;
    internal long Latitude => _latitude;
    internal long Longitude => _longitude;

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
