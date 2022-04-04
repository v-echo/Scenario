using SharedLibrary;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Implementation3.WebAPI.Services
{
    /// <summary>
    /// The calculation logic service. This is a stateless service (we don't persist any data and the dependency we have is also stateless), so it can live as singleton, scoped or transient.
    /// </summary>
    public class CalculatorService : ICalculator
    {
        IDividerService Divider { get; }
        ILogger<CalculatorService> Logger { get; }

        const string ErrorValue = "Error";
        const string CancelledValue = "Cancelled";

        public CalculatorService(IDividerService divider, ILogger<CalculatorService> logger)
        {
            Divider = divider;
            Logger = logger;
        }

        /// <summary>
        /// Starts a new (async) calculation on each call. It can return early if cancelled, but otherwise
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<StatusObject> GetDataAsync(CalculatorInput input, [EnumeratorCancellation] CancellationToken token = default)
        {
            string result;

            for (int i = input.Start; i <= input.End; i++)
            {
                if (token.IsCancellationRequested)
                    break;

                try
                {
                    result = await Divider.DivideAsync(i, new ReadOnlyDictionary<int, string>(GetDivisionLogic(input.First, input.Last)), input.MinDelaySeconds, input.MaxDelaySeconds, token);
                }
                catch (DividerException ex)
                {
                    result = ErrorValue;
                    Logger.LogError(ex, $"Known exception has ocurred for {i}.");
                }
                catch (TaskCanceledException ex)
                {
                    result = CancelledValue;
                    Logger.LogDebug(ex, $"Task was cancelled at {i}.");
                }
                catch (Exception ex)
                {
                    result = ErrorValue;
                    Logger.LogError(ex, $"Unexpected exception has ocurred for {i}.");
                }

                StatusType status = result switch
                {
                    ErrorValue => StatusType.Failed,
                    CancelledValue => StatusType.Cancelled,
                    _ when i == input.End => StatusType.Completed,
                    _ => StatusType.Running
                };

                yield return new StatusObject(status, ((i - input.Start + 1) * 100) / (input.End - input.Start + 1), result);
            }

            static Dictionary<int, string> GetDivisionLogic(string first, string last) => new()
            {
                { 15, $"{first} {last}" },
                { 3, first },
                { 5, last }
            };
        }
    }
}
