using SharedLibrary;

namespace Implementation3.WebAPI.Services
{
    public interface IIteratorService
    {
        Task<StatusObject?> GetStatus();
        Task StartSequence(CalculatorInput input, CancellationToken token = default);
    }
}