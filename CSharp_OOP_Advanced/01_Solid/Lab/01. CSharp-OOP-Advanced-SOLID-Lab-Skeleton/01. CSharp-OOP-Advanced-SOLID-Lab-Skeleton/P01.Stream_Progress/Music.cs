namespace P01.Stream_Progress
{
    public class Music : IStreamable
    {
        public Music(string artist, string album, int length, int bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Artist { get; }

        public string Album { get; }

        public int Length { get; }

        public int BytesSent { get; }
    }
}