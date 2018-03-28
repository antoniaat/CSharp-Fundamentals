namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamable;
        public StreamProgressInfo(IStreamable streamResult)
        {
            this.streamable = streamResult;
        }
        public int CalculateStreamProgress()
        {
            return (this.streamable.BytesSent * 100) /
                   this.streamable.Length;
        }

    }
}