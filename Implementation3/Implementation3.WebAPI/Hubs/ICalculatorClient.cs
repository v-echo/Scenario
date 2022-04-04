using SharedLibrary;

namespace Implementation3.WebAPI
{
    public interface ICalculatorClient
    {
        Task ReceiveStatus(StatusObject status);
    }
}
