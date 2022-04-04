using Implementation3.WebAPI.Services;
using Microsoft.AspNetCore.SignalR;
using SharedLibrary;
using System.Text.Json;

namespace Implementation3.WebAPI
{
    public class SignalRUpdater : Hub<ICalculatorClient>
    {
        ICalculator Calculator { get; }

        public SignalRUpdater(ICalculator calculator)
        {
            Calculator = calculator;
        }

        public async Task StartSequence(string json)
        {
            var input = JsonSerializer.Deserialize<CalculatorInput>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (input is null) return;

            // Acknowledge the request
            await Clients.Caller.ReceiveStatus(new StatusObject(StatusType.Started, 0));

            // Start the process
            await foreach (var result in Calculator.GetDataAsync(input).WithCancellation(Context.ConnectionAborted))
            {
                // Notify the subscribed clients with the updated progress status
                await Clients.Caller.ReceiveStatus(result);
            }
        }
    }
}
