using System;

public class Song
{
    private string name;
    private string artist;
    private int minutes;
    private int seconds;

    public Song(string name, string artist, int minutes, int seconds)
    {
        this.Name = name;
        this.Artist = artist;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }

            this.name = value;
        }
    }

    public string Artist
    {
        get => this.artist;
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            this.artist = value;
        }
    }

    public int Minutes
    {
        get => this.minutes;
        set
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get => this.seconds;
        set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            this.seconds = value;
        }
    }
}