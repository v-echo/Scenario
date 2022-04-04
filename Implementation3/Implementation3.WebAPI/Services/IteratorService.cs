using SharedLibrary;
using System.Collections.Concurrent;

namespace Implementation3.WebAPI.Services
{
    public class IteratorService : IIteratorService
    {
        ICalculator Calculator { get; }
        ConcurrentQueue<StatusObject> StatusUpdates { get; } = new();

        public IteratorService(ICalculator calculator)
        {
            Calculator = calculator;
        }

        public async Task StartSequence(CalculatorInput input, CancellationToken token = default)
        {
            StatusUpdates.Enqueue(new(StatusType.Started, 0));

            await foreach (var status in Calculator.GetDataAsync(input).WithCancellation(token))
            {
                StatusUpdates.Enqueue(status);
            }
        }

        public async Task<StatusObject?> GetStatus()
        {
            if (StatusUpdates.TryDequeue(out var status))
                return status;
            return null;
        }
    }
}
