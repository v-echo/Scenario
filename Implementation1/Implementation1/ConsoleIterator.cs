using SharedLibrary;

namespace Implementation1
{
    /// <summary>
    /// Iterates through a range specified by the constructor parameters. Makes use of the division functionality through DI.
    /// </summary>
    internal class ConsoleIterator : IIterator
    {
        IDivider Divider { get; }

        readonly int start;
        readonly int end;

        public ConsoleIterator(IDivider divider, int start, int end)
        {
            Divider = divider;
            this.start = start;
            this.end = end;
        }

        public async Task StartSequence(CancellationToken token = default)
        {
            foreach (var value in Enumerable.Range(start, end))
            {
                if (token.IsCancellationRequested)
                    return;

                Console.WriteLine(Divider.Divide(value));
            }
        }
    }
}
