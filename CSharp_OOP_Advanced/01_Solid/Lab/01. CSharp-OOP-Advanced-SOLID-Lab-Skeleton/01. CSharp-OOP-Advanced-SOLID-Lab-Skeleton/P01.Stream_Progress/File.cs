namespace P01.Stream_Progress
{
    public class File : IStreamable
    {
        public File(string name, int length, int bytesSent)
        {
            this.Name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Name { get; }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}