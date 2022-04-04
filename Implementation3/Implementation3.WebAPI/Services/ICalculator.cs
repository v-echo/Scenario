using SharedLibrary;

namespace Implementation3.WebAPI.Services
{
    /// <summary>
    /// The calculation logic. This should be a stateless service, to allow for different scopes.
    /// </summary>
    public interface ICalculator
    {
        IAsyncEnumerable<StatusObject> GetDataAsync(CalculatorInput input, CancellationToken token = default);
    }
}