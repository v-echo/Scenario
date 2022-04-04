
namespace Implementation3.WebAPI.Services
{
    public interface IDividerService
    {
        Task<string> DivideAsync(int value, IReadOnlyDictionary<int, string> dividers, int minDelaySeconds, int maxDelaySeconds, CancellationToken token = default);
    }
}