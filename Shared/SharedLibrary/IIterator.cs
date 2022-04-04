namespace SharedLibrary
{
    public interface IIterator
    {
        Task StartSequence(CancellationToken token = default);
    }
}