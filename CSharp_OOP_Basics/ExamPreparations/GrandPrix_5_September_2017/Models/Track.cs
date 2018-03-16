public class Track
{
    public Track(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
        this.Weather = Weather.Sunny;
        this.CurrentLap = 0;
    }

    public int LapsNumber { get; }

    public int TrackLength { get; }

    public int CurrentLap { get; set; }

    public Weather Weather { get; set; }
}