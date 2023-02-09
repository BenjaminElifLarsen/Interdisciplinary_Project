using Shared.DDD;

namespace Domain.DL.Models.MessageModels.ValueObjects;
public sealed record ObservationTimeAndLocation : ValueObject
{
    private DateTime _time;
    private double _latitude;
    private double _longitude;

    public DateTime Time { get => _time; private set => _time = value; }
    public double Latitude { get => _latitude; private set => _latitude = value; }
    public double Longitude { get => _longitude; private set => _longitude = value; }

    private ObservationTimeAndLocation()
    {

    }

    public ObservationTimeAndLocation(DateTime time, double latitude, double longitude)
    {
        _time = time;
        _latitude = latitude;
        _longitude = longitude;
    }
}
