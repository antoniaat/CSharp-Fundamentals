using System;
using System.Collections.Generic;

public class Launcher
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var playlist = new List<Song>();

        var hours = 0;
        var minutes = 0;
        var seconds = 0;

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            var artistName = tokens[0];
            var songName = tokens[1];
            var songMinutes = int.Parse(tokens[2]);
            var songSeconds = int.Parse(tokens[3]);

            try
            {
                var song = new Song(artistName, songName, songMinutes, songSeconds);
                playlist.Add(song);
                Console.WriteLine("Song added.");
                minutes += songMinutes;
                seconds += songSeconds;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            while (seconds > 59)
            {
                minutes++;
                seconds -= 60;
            }

            while (minutes > 59)
            {
                hours++;
                minutes -= 60;
            }
        }

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
    }
}