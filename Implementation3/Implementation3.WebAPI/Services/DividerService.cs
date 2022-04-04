namespace Implementation3.WebAPI.Services
{
    public class DividerService : IDividerService
    {
        public async Task<string> DivideAsync(int value, IReadOnlyDictionary<int, string> dividers, int minDelaySeconds, int maxDelaySeconds, CancellationToken token = default)
        {
            Random random = new();

            // Introduce a variable delay to the execution
            var delay = TimeSpan.FromSeconds(random.Next(minDelaySeconds, maxDelaySeconds));
            await Task.Delay(delay, token);

            // Throw an exception in ~15% of cases
            if (random.Next(1, 100) >= 85)
                throw new DividerException("Random exception!");

            // Calculate the result
            foreach (var divider in dividers.Keys)
                if (value % divider == 0)
                    return dividers[divider];

            return value.ToString();
        }
    }

    public class DividerException : Exception
    {
        public DividerException() : base() { }
        public DividerException(string message) : base(message) { }
    }
}
