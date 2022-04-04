namespace SharedLibrary
{
    public class StatusObject
    {
        public StatusObject(StatusType status, int progress, string? result = null)
        {
            Status = status;
            Progress = progress;
            Result = result;
        }

        public int Progress { get; }
        public string? Result { get; }
        public StatusType Status { get; }
    }
}
